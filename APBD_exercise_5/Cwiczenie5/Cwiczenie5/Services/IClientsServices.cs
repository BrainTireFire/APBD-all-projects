using Cwiczenie5.DTOs;
using Cwiczenie5.Models;

namespace Cwiczenie5.Services
{
    public interface IClientsServices
    {
        Task DeleteClient(Client client);
        Task<Client> GetClientByIdAsync(int idClient);
        Task<Client> GetClientByPeselAsync(string pesel);
        Task AddClient(CreateClientWithTrip createClientWithTrip);
        Task<IEnumerable<Client>> GetClient();
    }
}
