using Microsoft.EntityFrameworkCore;
using Products.API.Data;
using Products.API.Models;
using Products.API.Models.DTO;

namespace Products.API.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductsContext _context;

        public UserRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Login(LoginDTO login)
        {
             return await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
        }

        public async Task<UserModel> Save(UserModel user)
        {
            user.SetPasswordHash();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
