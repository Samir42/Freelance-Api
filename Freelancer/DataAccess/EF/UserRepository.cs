using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.DataAccess.EF {
    public class UserRepository : IUserRepository {
        private FreelanceDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserRepository(FreelanceDbContext ctx,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager) {
            this.ctx = ctx;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public Task AddAsync(User entity) {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> AddAsync(UserViewModel vm) {
            var user = new User { Email = vm.Email, UserName = vm.Email };
            var result = await userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded) {
                try {
                    await signInManager.SignInAsync(user, false);

                }
                catch { throw; };
            }
            return result;
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Edit(User entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            var data = await ctx.Users.Include(x => x.Freelancer)
                .ThenInclude(s => s.SkillsUsers)
                .ThenInclude(sk => sk.Skill)
                .Include(i => i.Client)
                .ToListAsync();

            return data;
        }

        public void Save() {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetFreelancersAsync() {
            var data = await ctx.Users.Include(x => x.Freelancer)
                .ThenInclude(s => s.SkillsUsers)
                .ThenInclude(sk => sk.Skill)
                .Where(x => x.Freelancer != null)
                .ToListAsync();

            return data;
        }

        public async Task<IEnumerable<User>> GetClientsAsync() {
            var data = await ctx.Users.Include(x => x.Freelancer)
                .ThenInclude(s => s.SkillsUsers)
                .ThenInclude(sk => sk.Skill)
                .Include(i => i.Client)
                .Where(x => x.Client != null)
                .ToListAsync();

            return data;
        }

        public async Task<User> GetAsync(int id) {
            return await this.ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmailAsync(string email) {
            var user = await ctx.Users.Include(x => x.Freelancer).FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }
    }
}
