using Cwiczenie6.Models;

namespace Cwiczenie6.Services
{
    public interface IRecipeService
    {
        Task<Prescription> GetPrescription(int IdPrescription);
        Task<bool> DoesPrescriptionExist(int IdPrescription);
    }
}
