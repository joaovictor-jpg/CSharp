using Domain.Interfaces;
using Entitites.Entities;
using Infrascture.Configuration;
using Infrascture.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.Repository.Repositories
{
    internal class RepositoryMessage : RepositoryGenerecs<Message>, IMessage
    {

        private readonly DbContextOptions<ContextBase> _OptionBuilder;

        public RepositoryMessage()
        {
            _OptionBuilder = new DbContextOptions<ContextBase>();
        }
    }
}
