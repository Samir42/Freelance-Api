using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IUserRepository : IRepository<User>{
        Task<IEnumerable<User>> GetFreelancersAsync();
        Task<IEnumerable<User>> GetClientsAsync();
        Task<User>  GetUserByEmailAsync(string email);
        Task<IdentityResult> AddAsync(UserViewModel vm);
       
    }
}
