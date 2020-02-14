using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.ViewModels;

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

        public User GetUserByEmail(string email) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync() {
            return userRepository.GetAllAsync();
        }

        public void SignUp(string email, string password) {
            userRepository.Add(new UserViewModel() { Email = email, Password = password });
        }

        public async Task<User> SignUp(UserViewModel model) {
            return await this.userRepository.Add(model);
        }
    }
}
