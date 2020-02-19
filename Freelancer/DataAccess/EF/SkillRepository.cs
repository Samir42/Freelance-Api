using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class SkillRepository : ISkillRepository {
        private FreelanceDbContext ctx;

        public SkillRepository(FreelanceDbContext ctx) => this.ctx = ctx;
        public Task AddAsync(Skill entity) {
            throw new NotImplementedException();
        }

        public async Task AddRangeAsync(IEnumerable<SkillUser> skillsUsers) {
            await this.ctx.SkillUsers.AddRangeAsync(skillsUsers);
            await this.ctx.SaveChangesAsync();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Edit(Skill entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> GetAllAsync() {
            return await this.ctx.Skills.ToListAsync();
        }

        public Task<Skill> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
