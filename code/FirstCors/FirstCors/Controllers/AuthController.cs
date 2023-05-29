using FirstCors.Application.Service;
using FirstCors.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstCors.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login( string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) BadRequest();

            if(login == "joao" &&  password == "123456")
            {
                var token = TokenService.GenerateToken(new EmployeeModel("joao", 23, null));
                return Ok(token);
            }

            return NotFound();
        }
    }
}
