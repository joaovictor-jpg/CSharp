using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException("Not Found");
            _signInManager = signInManager ?? throw new ArgumentNullException("Not Found");
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddUser([FromBody] Login login)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password) || string.IsNullOrWhiteSpace(login.Cpf))
            {
                return BadRequest("Falto alguns campos");
            }
            var user = new ApplicationUser
            {
                Email = login.Email,
                UserName = login.Email,
                CPF = login.Cpf
            };
            var result = await _userManager.CreateAsync(user, login.Password);
            if(result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            // Geração de confirmação caso precise
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //Retorno do email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var respose_Retorn = await _userManager.ConfirmEmailAsync(user, code);

            if(respose_Retorn.Succeeded)
            {
                return Ok("Usuário Adcionado!");
            }
            else
            {
                return BadRequest("Erro ao confirma cadastro de usuário!");
            }
        }
    }
}
