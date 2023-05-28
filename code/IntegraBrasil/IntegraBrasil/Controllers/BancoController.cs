using IntegraBrasil.Repository.Banco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IntegraBrasil.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpGet("buscar/todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodos()
        {
            var response = await _bancoService.BuscarTodos();

            if (response.CodigoHttp != System.Net.HttpStatusCode.OK) return StatusCode((int)response.CodigoHttp, response.ErroRetorno);

            return Ok(response.DadosRetorno);
        }

        [HttpGet("buscar/{codigoBanco}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Buscar([RegularExpression("[0-9]*$")]string codigoBanco)
        {
            var response = await _bancoService.BuscarBanco(codigoBanco);

            if (response.CodigoHttp != System.Net.HttpStatusCode.OK) return StatusCode((int)response.CodigoHttp, response.ErroRetorno);

            return Ok(response.DadosRetorno);
        }

    }
}
