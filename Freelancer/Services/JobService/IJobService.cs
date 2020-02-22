using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.JobService {
    public interface IJobService {
        Task<IEnumerable<Job>> GetAllAsync();
        Task<IEnumerable<Job>> GetAllAsync(int clientId);
        Task<Job> GetJobById(int id);
        Task<IEnumerable<Request>> GetRequestsAsync(int id);
        Task<int> PostJobAsync(JobViewModel vm);
        Task UpdateJobAsync(JobViewModel vm);

        Task<IEnumerable<Job>> GetDoneProjectsByFreelancerIdAsync(int freelancerId);
    }
}
