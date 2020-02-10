using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Services.UserService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class FreelancerRepository : IFreelancerRepository {
        public void Add(Domain.Entities.Freelancer entity) {
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

        public Task<Domain.Entities.Freelancer> Get(int id) {
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
