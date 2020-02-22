using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IJobRepository : IRepository<Job> {
        Task<IEnumerable<Request>> GetRequestsAsync(int id);
        Task<IEnumerable<Job>> GetAllAsync(int clientId);
        Task<int> PostAsync(Job entity);
        Task EditAsync(Job entity);

        Task<IEnumerable<Job>> GetDoneProjectsByFreelancerIdAsync(int freelancerId);
    }
}
