using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IProposalRepository : IRepository<Request> {
        Task<IEnumerable<Request>> GetProposalsByJobIdAsync(int id);
        Task<IEnumerable<Request>> GetProposalsByFreelancerIdAsync(int id);
    }
}
