using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Freelancer.Services.FreelancerService {
    public class FreelancerService : IFreelancerService {
        private readonly IFreelancerRepository freelancerRepository;

        public FreelancerService(IFreelancerRepository repo) {
            freelancerRepository = repo;
        }

        public async Task AddAsync(Domain.Entities.Freelancer fl) {
            await freelancerRepository.AddAsync(fl);
        }


        public async Task<IEnumerable<Domain.Entities.Freelancer>> GetFreelancersAsync() {
            return await freelancerRepository.GetAllAsync();
        }
    }
}
