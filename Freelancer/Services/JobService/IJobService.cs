using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.JobService {
    public interface IJobService {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<IEnumerable<Request>> GetRequestsAsync(int id);
    }
}
