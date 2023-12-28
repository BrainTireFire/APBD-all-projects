using PrzykladoweKolokwium2_2.Models;

namespace PrzykladoweKolokwium2_2.Services
{
    public interface IDbService
    {
        Task<bool> DoesAnimalExist(int animalID);
        Task<Animal> GetAnimalData(int animalID);
        Task<bool> DoesOwnerExist(int ownerID);
        Task<bool> DoesProcedureExist(int procedureID);
        Task<AnimalClass?> GetAnimalClassByName(string name);
        Task AddAnimal(Animal animal);
        Task AddAnimalProcedures(IEnumerable<ProcedureAnimal> procedures);
    }
}
