using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Freelancer.Domain.Abstractions;
using Freelancer.Domain.Entities;

namespace Freelancer.DataAccess.EF {
    public class ClientRepository : IClientRepository {
        private FreelanceDbContext ctx;

        public ClientRepository(FreelanceDbContext ctx) => this.ctx = ctx;
        public Task AddAsync(Client entity) {
            throw new NotImplementedException();
        }

        public async Task AddAsync(string companyName, int userId) {
            await this.ctx.Clients.AddAsync(new Client() { CompanyName = companyName, UserForeignKey = userId });
            await this.ctx.SaveChangesAsync();
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public void Edit(Client entity) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> FindAsync(Expression<Func<Client, bool>> predicate) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Client> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public void Save() {
            throw new NotImplementedException();
        }
    }
}
