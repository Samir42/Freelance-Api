using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.JobService {
    public class JobService : IJobService {
        private readonly IJobRepository jobRepository;

        public JobService(IJobRepository jobRepository) => this.jobRepository = jobRepository;

        public async Task<IEnumerable<Job>> GetAllAsync() {
            return await jobRepository.GetAllAsync();
        }

        public async Task<Job> GetJobById(int id) {
            return await jobRepository.Get(id);
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync(int id) {
           return  await jobRepository.GetRequestsAsync(id);
        }
    }
}
