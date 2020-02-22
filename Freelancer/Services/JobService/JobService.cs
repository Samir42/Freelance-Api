using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
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

        public async Task<IEnumerable<Job>> GetAllAsync(int clientId) {
            return await jobRepository.GetAllAsync(clientId);
        }

        public async Task<IEnumerable<Job>> GetDoneProjectsByFreelancerIdAsync(int freelancerId) {
            return await this.jobRepository.GetDoneProjectsByFreelancerIdAsync(freelancerId);
        }

        public async Task<Job> GetJobById(int id) {
            return await jobRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Request>> GetRequestsAsync(int id) {
            return await jobRepository.GetRequestsAsync(id);
        }

        public async Task<int> PostJobAsync(JobViewModel vm) {
            return await this.jobRepository.PostAsync(new Job() {
                ClientId = vm.ClientId,
                Title = vm.Title,
                Description = vm.Description,
                Price = vm.Price,
            });
        }

        public async Task UpdateJobAsync(JobViewModel vm) {
            await this.jobRepository.EditAsync(new Job() {
                Title = vm.Title,
                ClientId = vm.ClientId,
                Description = vm.Description,
                FreelancerId = vm.FreelancerId,
                Id = vm.Id,
                Price = vm.Price
            });
        }
    }
}
