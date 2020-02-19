using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IFreelancerRepository : IRepository<Domain.Entities.Freelancer> {
        Task AddAsync(FreelancerViewModel vm);
    }
}
