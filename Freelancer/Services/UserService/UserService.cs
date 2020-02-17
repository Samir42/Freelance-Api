using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Freelancer.Services.UserService {
    public class UserService : IUserService {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public async Task<User> GetAsync(int id) {
            return await this.userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetClientsAsync() {
            return await userRepository.GetClientsAsync();
        }

        public async Task<IEnumerable<User>> GetFreelancersAsync() {
            return await userRepository.GetFreelancersAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email) {
            return await this.userRepository.GetUserByEmailAsync(email);
        }

        public Task<IEnumerable<User>> GetUsersAsync() {
            return userRepository.GetAllAsync();
        }


        public async Task<IdentityResult> SignUpAsync(UserViewModel model) {
            return await this.userRepository.AddAsync(model);
        }
    }
}
