using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class JobRepository : IJobRepository {
        private readonly FreelanceDbContext ctx;

        public JobRepository(FreelanceDbContext ctx) => this.ctx = ctx;

        public void Add(Job entity) {
            throw new NotImplementedException();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }
        public void Edit(Job entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Job>> FindAsync(Expression<Func<Job, bool>> predicate) {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Job>> GetAllAsync() {
            return await this.ctx.Jobs.Include(x => x.JobsSkills)
                                      .ThenInclude(a=> a.Skill)
                                      .Include(x=> x.Client)
                                      .Include(x=> x.Requests)
                                      .ThenInclude(x=> x.Freelancer)
                                      .ThenInclude(x=> x.User)
                                      .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync(int id) {
            return await this.ctx.Requests.Include(x=> x.Freelancer)
                                          .ThenInclude(x=> x.User)
                                          .Include(x=> x.Job)
                                          .Where(x => x.JobId == id)
                                          .ToListAsync();
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public async Task<Job> GetAsync(int id) {
            return await this.ctx.Jobs.Include(x=> x.JobsSkills)
                                      .ThenInclude(x=> x.Skill)
                                      .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
