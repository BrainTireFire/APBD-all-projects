using Cwiczenie5.Data;
using Cwiczenie5.DTOs;
using Cwiczenie5.Models;
using Cwiczenie5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Cwiczenie5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsServices _tripsServices;
        private readonly IClientsServices _clientServices;
        public TripsController(ITripsServices tripsServices, IClientsServices clientServices)
        {
            _tripsServices = tripsServices;
            _clientServices = clientServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _tripsServices.GetTripsWithAdditionalData();
            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> CreateTrip(int idTrip, CreateClientWithTrip createClientWithTrip)
        {
            if (createClientWithTrip == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid client data");
            }
            var clientExisting = await _clientServices.GetClientByPeselAsync(createClientWithTrip.Pesel);
            if (clientExisting == null)
            {
                await _clientServices.AddClient(createClientWithTrip);
            }
            clientExisting = await _clientServices.GetClientByPeselAsync(createClientWithTrip.Pesel);

            var existingTrip = await _tripsServices.GetTripByIdAsync(createClientWithTrip.TripID);
            if (existingTrip == null)
            {
                return BadRequest("Trip does not exist");
            }

            var exisitngClientTrip = existingTrip.ClientTrips.FirstOrDefault(ct => ct.IdClient == clientExisting.IdClient);
            if (exisitngClientTrip != null)
            {
                return BadRequest("Client is already registered for the trip");
            }

            var tripClient = new TripClientDto
            {
                IdClient = clientExisting.IdClient,
                IdTrip = createClientWithTrip.TripID,
                PaymentDate = createClientWithTrip.PaymentDate,
            };

            await _tripsServices.AddTrip(tripClient);
            return Created("{tripId}/clients", createClientWithTrip);
        }
    }
}
