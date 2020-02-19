using Freelancer.DataAccess.EF;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Freelancer.Services.ClientService;
using Freelancer.Services.FreelancerService;
using Freelancer.Services.JobService;
using Freelancer.Services.ProposalService;
using Freelancer.Services.SkillService;
using Freelancer.Services.TokenService;
using Freelancer.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Freelancer {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(serv => serv.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();  
            services.AddScoped<IProposalService, ProposalService>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITokenService, TokenService>();

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


            //JWT

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            //services.AddAuthentication(x => {
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(x => {
            //        x.RequireHttpsMetadata = false;
            //        x.SaveToken = true;
            //        x.TokenValidationParameters = new TokenValidationParameters {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key), // one = secret
            //            ValidateIssuer = false,
            //            ValidateAudience = false,

            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
