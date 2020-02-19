using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Freelancer.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class FreelancerRepository : IFreelancerRepository {
        private FreelanceDbContext ctx;

        public FreelancerRepository(FreelanceDbContext ctx) => this.ctx = ctx;
        public async Task AddAsync(Domain.Entities.Freelancer entity) {
            await ctx.Freelancers.AddAsync(entity);
            await ctx.SaveChangesAsync();
        }

        public Task AddAsync(FreelancerViewModel vm) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Edit(Domain.Entities.Freelancer entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Freelancer>> FindAsync(Expression<Func<Domain.Entities.Freelancer, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Freelancer> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.Freelancer>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }

       
    }
}
