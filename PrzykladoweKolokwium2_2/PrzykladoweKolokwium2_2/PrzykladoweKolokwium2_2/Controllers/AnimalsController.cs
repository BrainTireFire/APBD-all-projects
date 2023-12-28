using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium2_2.Models;
using PrzykladoweKolokwium2_2.Models.DTOs;
using PrzykladoweKolokwium2_2.Services;
using System.Transactions;

namespace PrzykladoweKolokwium2_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IDbService _dbService;
        public AnimalsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        [Route("{animalID}")]
        public async Task<IActionResult> GetAnimalData(int animalID)
        {
            if(!await _dbService.DoesAnimalExist(animalID))
                return NotFound($"Owner with given ID - {animalID} doesn't exist");

            var res = await _dbService.GetAnimalData(animalID);
            return Ok(new GetAnimalDataDTO
            {
                ID = res.ID,
                Name = res.Name,
                AnimalClass = res.AnimalClass.Name,
                AdmissionDate = res.AdmissionDate,
                Owner = new GetAnimalDataOwnerDTO
                {
                    ID = res.Owner.ID,
                    FirstName = res.Owner.FirstName,
                    LastName = res.Owner.LastName,
                },
                Procedures = res.ProcedureAnimals.Select(e => new GetAnimalDataProcedureDTO
                {
                    Name = e.Procedure.Name,
                    Date = e.Date
                }).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAnimal(AddNewAnimalDTO newAnimalData)
        {
            if (!await _dbService.DoesOwnerExist(newAnimalData.OwnerID))
                return NotFound($"Owner with given ID - {newAnimalData.OwnerID} doesn't exist");

            var animalClass = await _dbService.GetAnimalClassByName(newAnimalData.AnimalClass);
            if (animalClass == null)
                return NotFound($"AnimalClass with given name - {newAnimalData.AnimalClass} doesn't exist");

            var animal = new Animal
            {
                Name = newAnimalData.Name,
                AnimalClass = animalClass,
                OwnerID = newAnimalData.OwnerID,
                AdmissionDate = newAnimalData.AdmissionDate,
            };

            var procedures = new List<ProcedureAnimal>();
            foreach (var procedure in newAnimalData.Procedures)
            {
                if(!await _dbService.DoesProcedureExist(procedure.ProcedureID))
                    return NotFound($"Procedure with given ID - {procedure.ProcedureID} doesn't exist");

                procedures.Add(new ProcedureAnimal
                {
                    ProcedureID = procedure.ProcedureID,
                    Date = procedure.Date,
                    Animal = animal
                });
            }
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _dbService.AddAnimal(animal);
                await _dbService.AddAnimalProcedures(procedures);

                scope.Complete();
            }

            return Created("api/animals", "");
        }
    }
}
