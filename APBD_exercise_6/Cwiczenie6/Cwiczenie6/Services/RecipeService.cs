using Cwiczenie6.Data;
using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie6.Services
{
    public class RecipeService : IRecipeService
    {
        public readonly DataContext _context;
        public RecipeService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DoesPrescriptionExist(int IdPrescription)
        {
            return await _context.Prescriptions.AnyAsync(e => e.IdPrescription == IdPrescription);
        }

        public async Task<Prescription> GetPrescription(int IdPrescription)
        {
            return await _context.Prescriptions
                .Include(e => e.Patient)
                .Include(e => e.Doctor)
                .Include(e => e.PrescriptionMedicaments)
                .ThenInclude(e => e.Medicament)
                .Where(e => e.IdPrescription == IdPrescription)
                .FirstAsync();
        }

    }
}
