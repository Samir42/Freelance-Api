﻿using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;
using Freelancer.ViewModels;
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

        public UserRepository(FreelanceDbContext ctx) => this.ctx = ctx;

        public void Add(User entity) {
            throw new NotImplementedException();
        }

        public async void Add(UserViewModel vm) {
            var user = new User { Email = vm.Email, UserName = vm.Email };
            var result = await userManager.CreateAsync(user, vm.Password);

            //if (result.Succeeded) {
            await signInManager.SignInAsync(user, false);
            //}
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

        public Task<User> Get(int id) {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<User>> GetAllAsync() {
            var data = await ctx.Users.Include(x => x.Freelancer)
                .ThenInclude(s=> s.SkillsUsers)
                .ThenInclude(sk => sk.Skill)
                .Include(i=> i.Client)
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
                .Include(i=> i.Client)
                .Where(x => x.Client != null)
                .ToListAsync();

            return data;
        }

        public void Dispose() {
            Console.WriteLine("User repository disposed");
        }
    }
}