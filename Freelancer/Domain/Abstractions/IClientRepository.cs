using Freelancer.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace Freelancer.Domain.Abstractions {
    public interface IClientRepository  : IRepository<Client>{
        Task AddAsync(string companyName, int userId);
    }
}
