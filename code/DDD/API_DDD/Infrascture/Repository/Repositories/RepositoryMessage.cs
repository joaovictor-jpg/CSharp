using Domain.Interfaces;
using Entitites.Entities;
using Infrascture.Configuration;
using Infrascture.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrascture.Repository.Repositories
{
    public class RepositoryMessage : RepositoryGenerecs<Message>, IMessage
    {

        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryMessage()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Message>> ListarMessage(Expression<Func<Message, bool>> exMessage)
        {
            using(var banco = new ContextBase(_OptionBuilder))
            {
                return await banco.Messages.Where(exMessage).AsTracking().ToListAsync();
            }
        }
    }
}
