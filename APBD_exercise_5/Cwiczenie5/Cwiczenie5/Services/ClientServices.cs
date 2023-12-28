using Cwiczenie5.Data;
using Cwiczenie5.DTOs;
using Cwiczenie5.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie5.Services
{
    public class ClientServices : IClientsServices
    {
        public readonly ApbdContext _context;
        public ClientServices(ApbdContext context) 
        { 
            _context = context;
        }
        public async Task DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task AddClient(CreateClientWithTrip createClientWithTrip)
        {
            var maxId = await GetMaxClientId();

            var client = new Client
            {
                IdClient = maxId + 1,
                FirstName = createClientWithTrip.FirstName,
                LastName = createClientWithTrip.LastName,
                Email = createClientWithTrip.Email,
                Telephone = createClientWithTrip.Telephone,
                Pesel = createClientWithTrip.Pesel
            };
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetClient()
        {
            return await _context.Clients
                .Select(e => new Client
                {
                    IdClient = e.IdClient,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Telephone = e.Telephone,
                    Pesel = e.Pesel,
                    ClientTrips = (ICollection<ClientTrip>)e.ClientTrips.Select(c => new ClientTrip { IdClient = c.IdClient, IdTrip = c.IdTrip, PaymentDate = c.PaymentDate, RegisteredAt = c.RegisteredAt }),
                }).ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int idClient)
        {
            return await _context.Clients.Include(ct => ct.ClientTrips).FirstOrDefaultAsync(e => e.IdClient == idClient);
        }

        public async Task<Client> GetClientByPeselAsync(string pesel)
        {
            return await _context.Clients.Include(ct => ct.ClientTrips).FirstOrDefaultAsync(e => e.Pesel == pesel);
        }

        private async Task<int> GetMaxClientId()
        {
            int maxId = await _context.Clients.MaxAsync(c => c.IdClient);
            return maxId;
        }
    }
}
