using Freelancer.Domain.Entities;
using Freelancer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IUserRepository : IRepository<User>{
        Task<IEnumerable<User>> GetFreelancersAsync();
        Task<IEnumerable<User>> GetClientsAsync();
        Task<User>  GetUserByEmailAsync(string email);
        Task<User> Add(UserViewModel vm);
       
    }
}
