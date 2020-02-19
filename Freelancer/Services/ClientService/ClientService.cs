using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;

namespace Freelancer.Services.ClientService {
    public class ClientService : IClientService {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository) {
            this.clientRepository = clientRepository;
        }

        public async Task AddAsync(string companyName,int userId) {
            await this.clientRepository.AddAsync(companyName, userId);
        }

        public  Task<IEnumerable<Client>> GetClientsAsync() {
            throw new NotImplementedException();
        }
    }
}
