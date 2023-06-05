using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entitites.Entities;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _message;

        public ServiceMessage(IMessage message)
        {
            _message = message;
        }

        public async Task Adcionar(Message message)
        {
            var validarTitulo = message.ValidarPropriedadeString(message.titulo, "Titulo");
            if(validarTitulo)
            {
                message.DataCadastro = DateTime.Now;
                message.DataAlteracao = DateTime.Now;
                message.Ativo = true;
                await _message.Add(message);
            }
        }

        public async Task Atualizar(Message message)
        {
            var validarTitulo = message.ValidarPropriedadeString(message.titulo, "Titulo");
            if (validarTitulo)
            {
                message.DataAlteracao = DateTime.Now;
                await _message.Update(message);
            }
        }

        public async Task<List<Message>> ListarMessageAtivas()
        {
            return await _message.ListarMessage(m => m.Ativo);
        }
    }
}
