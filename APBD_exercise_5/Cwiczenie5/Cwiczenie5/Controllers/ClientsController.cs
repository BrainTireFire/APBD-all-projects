using Cwiczenie5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly IClientsServices _clientsServices;
        public ClientsController(IClientsServices clientsServices) 
        {
            _clientsServices = clientsServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var clients = await _clientsServices.GetClient();
            return Ok(clients);
        }

        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _clientsServices.GetClientByIdAsync(idClient);
            if (client == null)
            {
                return NotFound("Client does not exists");
            }
            if (client.ClientTrips.Count > 0) {
                return BadRequest("Client has got assign one or more trips");
            }

            await _clientsServices.DeleteClient(client);
            return Ok("Client was correctly removed");
        }
    }
}
