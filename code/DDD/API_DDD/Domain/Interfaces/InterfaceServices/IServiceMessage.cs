using Entitites.Entities;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceMessage
    {
        Task Adcionar(Message message);
        Task Atualizar(Message message);
        Task<List<Message>> ListarMessageAtivas();
    }
}
