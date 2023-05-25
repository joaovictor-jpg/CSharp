using Products.API.Models;
using Products.API.Models.DTO;

namespace Products.API.Repository.Users
{
    public interface IUserRepository
    {
        Task<UserModel> Save(UserModel model);
        Task<UserModel> Login(LoginDTO login);
    }
}
