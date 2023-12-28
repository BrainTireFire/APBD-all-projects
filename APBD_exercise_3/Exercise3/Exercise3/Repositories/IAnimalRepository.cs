using Exercise3.Models;
using Exercise3.Models.DTOs;

namespace Exercise3.Repositories
{
    public interface IAnimalRepository
    {
        Task<ICollection<Animal>> GetAnimalsAsync(string orderBy);
        Task AddAnimal(AnimalPOST animalPOST);
        Task UpdateAnimal(int animalID, AnimalPUT animalPUT);
        Task DeleteAnimal(int animalID);
        Task<bool> DoesAnimalExist(int ID);
    }
}
