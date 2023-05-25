using Products.API.Models;

namespace Products.API.Repository.Users
{
    public interface IUserRepository
    {
        Task<UserModel> Save(UserModel model);
    }
}
