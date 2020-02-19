using Freelancer.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Freelancer.Services.ClientService {
    public interface IClientService {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task AddAsync(string companyName, int userId);
    }
}
