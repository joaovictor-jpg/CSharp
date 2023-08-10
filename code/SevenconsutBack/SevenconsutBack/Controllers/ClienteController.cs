using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenconsutBack.Model;
using SevenconsutBack.Repository;

namespace SevenconsutBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClientRepository _clientRepository;

        public ClienteController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("/Client")]
        public async Task<ActionResult> GetClient()
        {
            return Ok(await _clientRepository.GetClient());
        }

        [HttpPost]
        [Route("/client")]
        public async Task<ActionResult> Save(Client client)
        {
            return Created($"Client/client/{client.Id}", new
            {
                data = await _clientRepository.Save(client),
                success = true,
                message = "Create client with success"
            });
        }

        [HttpPut]
        [Route("/client")]
        public async Task<ActionResult> UpdateClient(Client clientNew)
        {
            Client client = await _clientRepository.GetClientById(clientNew.Id);

            if (client == null) return NotFound("client not found");

            client.Name = clientNew.Name;
            client.Email = clientNew.Email;

            return Ok(new
            {
                data = await _clientRepository.Update(client),
                success = true,
                message = "Client updated"
            });
        }

        [HttpDelete]
        [Route("/client")]
        public async Task<ActionResult> Delet(int id)
        {
            Client client = await _clientRepository.GetClientById(id);

            if (client == null) return NotFound("client not found");

            await _clientRepository.Delete(client);
            return NoContent();
        }

    }
}
