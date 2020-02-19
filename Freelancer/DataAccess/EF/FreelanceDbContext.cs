using Freelancer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Freelancer.DataAccess.EF {
    public class FreelanceDbContext : IdentityDbContext<
            User,
            Role,
            int,
            IdentityUserClaim<int>,
            UserRole,
            IdentityUserLogin<int>,
            IdentityRoleClaim<int>,
            IdentityUserToken<int>> {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Domain.Entities.Freelancer> Freelancers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobsSkill> JobsSkills { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Revoke> Revokes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillUser> SkillUsers { get; set; }

        public FreelanceDbContext(DbContextOptions<FreelanceDbContext> options)
           : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Request>()
                .HasOne(h => h.Job)
                .WithMany(w => w.Requests)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasOne(u => u.Freelancer)
                .WithOne(i => i.User)
                .HasForeignKey<Domain.Entities.Freelancer>(b => b.UserForeignKey);

            builder.Entity<User>()
                .HasOne(u => u.Client)
                .WithOne(i => i.User)
                .HasForeignKey<Client>(b => b.UserForeignKey);

            builder.Entity<Domain.Entities.Freelancer>()
                .HasIndex(u => u.UserForeignKey)
                .IsUnique();


            builder.Entity<Job>()
                .Property(p => p.OpenedAt)
                .HasDefaultValue(DateTime.Now);

            builder.Entity<User>()
                .Property(x => x.RegisteredAt)
                .HasDefaultValue(DateTime.Now);

            builder.Entity<Job>()
                .Property(x => x.ClientId)
                .IsRequired();

            builder.Entity<Request>()
                .Property(x => x.FreelancerId)
                .IsRequired();

            builder.Entity<Request>()
                .Property(x => x.JobId)
                .IsRequired(); 
            
            builder.Entity<Request>()
                .Property(x=> x.RequestDescription)
                .IsRequired();
            
            builder.Entity<Request>()
                .Property(x=> x.HowManyDay)
                .IsRequired();

            builder.Entity<Request>()
                .HasIndex(p => new { p.FreelancerId, p.JobId })
                .IsUnique();

                
            //builder.Entity<AppliedJob>()
            //    .HasOne(h => h.Job)
            //    .WithMany(w => w.AppliedJobs)
            //    .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}
