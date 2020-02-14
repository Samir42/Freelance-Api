using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.ProposalService {
    public interface IProposalService {
        Task<IEnumerable<Request>> GetProposalsByJobIdAsync(int jobId);
        Task AddAsync(ProposalViewModel model);
    }
}
