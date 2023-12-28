using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwium2_2.Data;
using PrzykladoweKolokwium2_2.Models;

namespace PrzykladoweKolokwium2_2.Services
{
    public class DbService : IDbService
    {
        private readonly DatabaseContext _context;
        public DbService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAnimal(Animal animal)
        {
            await _context.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task AddAnimalProcedures(IEnumerable<ProcedureAnimal> procedures)
        {
            await _context.AddRangeAsync(procedures);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesAnimalExist(int animalID)
        {
            return await _context.Animals.AnyAsync(e => e.ID == animalID);
        }

        public async Task<bool> DoesOwnerExist(int ownerID)
        {
            return await _context.Owners.AnyAsync(e => e.ID == ownerID);
        }

        public async Task<bool> DoesProcedureExist(int procedureID)
        {
            return await _context.Procedures.AnyAsync(e => e.ID == procedureID);
        }

        public async Task<AnimalClass?> GetAnimalClassByName(string name)
        {
            return await _context.AnimalClasses.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Animal> GetAnimalData(int animalID)
        {
            return await _context.Animals
                .Include(e => e.Owner)
                .Include(e => e.AnimalClass)
                .Include(e => e.ProcedureAnimals)
                .ThenInclude(e => e.Procedure)
                .Where(e => e.ID == animalID)
                .FirstAsync();
        }
    }
}
