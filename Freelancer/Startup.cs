using Freelancer.DataAccess.EF;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Services.FreelancerService;
using Freelancer.Services.JobService;
using Freelancer.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Freelancer {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(serv => serv.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>(); 
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();

            services
            .AddDbContext<FreelanceDbContext>(x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Freelancer;Trusted_Connection=True;"));

            services.AddIdentity<User, Role>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                options.Lockout.MaxFailedAccessAttempts = 4;
            })
                .AddEntityFrameworkStores<FreelanceDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
