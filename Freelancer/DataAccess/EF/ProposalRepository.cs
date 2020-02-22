using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class ProposalRepository : IProposalRepository {
        private FreelanceDbContext ctx;

        public ProposalRepository(FreelanceDbContext ctx) {
            this.ctx = ctx;
        }
        public async Task AddAsync(Request entity) {
            await this.ctx.AddAsync(entity);
            await this.ctx.SaveChangesAsync();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Edit(Request entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> FindAsync(Expression<Func<Request, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Request>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Request> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> GetProposalsByFreelancerIdAsync(int id) {
            return await this.ctx.Requests.Include(x => x.Freelancer)
                                          .ThenInclude(x => x.User)
                                          .Include(x => x.Job)
                                          .Where(x => x.FreelancerId == id)
                                          .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetProposalsByJobIdAsync(int id) {
            return await this.ctx.Requests.Include(x => x.Freelancer)
                                           .ThenInclude(x => x.User)
                                           .Include(x => x.Job)
                                           .Where(x => x.JobId == id)
                                           .ToListAsync();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
