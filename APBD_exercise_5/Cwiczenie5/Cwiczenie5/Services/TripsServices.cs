using Cwiczenie5.Data;
using Cwiczenie5.DTOs;
using Cwiczenie5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie5.Services
{
    public class TripsServices : ITripsServices
    {
        private readonly ApbdContext _context;
        public TripsServices(ApbdContext context) {
            _context = context;
        }

        public async Task AddTrip(TripClientDto tripClientDto)
        {
            var clientTrip = new ClientTrip
            {
                IdClient = tripClientDto.IdClient,
                IdTrip = tripClientDto.IdTrip,
                PaymentDate = tripClientDto.PaymentDate ?? null,
                RegisteredAt = DateTime.UtcNow
            };
            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TripWithAdditionalData>> GetTripsWithAdditionalData()
        {
            return await _context.Trips
                .OrderByDescending(e => e.DateFrom)
                .Select(e => new TripWithAdditionalData
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    MaxPeople = e.MaxPeople,
                    Countries = e.Countries.Select(c => new ContryName { Name = c.Name }),
                    Clients = e.ClientTrips.Select(c => new ClientFullName { FirstName = c.Client.FirstName, LastName = c.Client.LastName,})
                }).ToListAsync();
        }

        public async Task<Trip> GetTripByIdAsync(int idTrip)
        {
            return await _context.Trips.FirstOrDefaultAsync(e => e.IdTrip == idTrip);
        }
    }
}
