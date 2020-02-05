using Freelancer.Domain.Entities;
using Freelancer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IUserRepository : IRepository<User>, IDisposable{
        Task<IEnumerable<User>> GetFreelancersAsync();
        Task<IEnumerable<User>> GetClientsAsync();
        void Add(UserViewModel vm);
       
    }
}
