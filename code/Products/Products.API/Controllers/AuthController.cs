using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Config;
using Products.API.Models;
using Products.API.Models.DTO;
using Products.API.Repository.Users;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AuthController(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserModel user)
        {
            user = await _repository.Save(user);

            var token = GenerateToken.Token(user);

            return Ok(new
            {
                user = new
                {
                    name = user.Name,
                    email = user.Email
                },
                token = token
            });
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _repository.Login(login);

            if (user == null) return Unauthorized();

            if(user.PasswordIsValida(login.Password))
            {
                var token = GenerateToken.Token(user);

                return Ok(new
                {
                    user = new
                    {
                        name = user.Name,
                        email = user.Email
                    },
                    token = token
                });
            }

            return Unauthorized();

        }
    }
}
