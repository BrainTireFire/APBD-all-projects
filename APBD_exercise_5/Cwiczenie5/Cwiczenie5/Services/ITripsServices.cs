using Cwiczenie5.DTOs;
using Cwiczenie5.Models;

namespace Cwiczenie5.Services
{
    public interface ITripsServices
    {
        Task<IEnumerable<TripWithAdditionalData>> GetTripsWithAdditionalData();
        Task AddTrip(TripClientDto tripClientDto);
        Task<Trip> GetTripByIdAsync(int idTrip);
    }
}
