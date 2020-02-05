using Freelancer.Domain.Entities;
using Freelancer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Services.UserService {
    public interface IUserService {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<User>> GetFreelancersAsync();
        Task<IEnumerable<User>> GetClientsAsync();
        User GetUserByEmail(string email);
        void SignUp(string email, string password);
    }
}
