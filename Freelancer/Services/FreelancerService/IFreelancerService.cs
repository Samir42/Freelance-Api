using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.FreelancerService {
    public interface IFreelancerService {
        Task<IEnumerable<Domain.Entities.Freelancer>> GetFreelancersAsync();
        Task AddAsync(Domain.Entities.Freelancer fl);
    }
}
