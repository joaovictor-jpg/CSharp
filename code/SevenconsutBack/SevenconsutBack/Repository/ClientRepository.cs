using Microsoft.EntityFrameworkCore;
using SevenconsutBack.Data;
using SevenconsutBack.Model;

namespace SevenconsutBack.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BaseContext _baseContext;

        public ClientRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<Client> Delete(Client client)
        {
            _baseContext.Remove(client);
            await _baseContext.SaveChangesAsync();

            return client;
        }

        public Task<Client> GetClientById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetProductById(int id)
        {
            return await _baseContext.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Client>> GetClient()
        {
            return await _baseContext.Clients.ToListAsync();
        }

        public async Task<Client> Save(Client client)
        {
            await _baseContext.Clients.AddAsync(client);
            await _baseContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> Update(Client client)
        {
            _baseContext.Clients.Update(client);
            await _baseContext.SaveChangesAsync();
            return client;
        }
    }
}
