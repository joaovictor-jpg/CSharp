using SevenconsutBack.Model;

namespace SevenconsutBack.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClient();

        Task<Client> GetClientById(int id);

        Task<Client> Save(Client client);

        Task<Client> Update(Client client);

        Task<Client> Delete(Client client);
    }
}
