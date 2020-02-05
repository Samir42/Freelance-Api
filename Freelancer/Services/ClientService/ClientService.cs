using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Freelancer.Domain.Entities;

namespace Freelancer.Services.ClientService {
    public class ClientService : IClientService {
        public Task<IEnumerable<Client>> GetClientsAsync() {
            throw new NotImplementedException();
        }
    }
}
