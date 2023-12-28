using Exercise3.Models;
using Exercise3.Models.DTOs;
using Exercise3.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        // GET: api/<AnimalsController>
        [HttpGet]
        public async Task<IActionResult> GetAnimalsAsync(string? orderBy)
        {
            if (orderBy is null) 
            { 
                orderBy = "name";
            }
            else
            {
                string[] acceptedOrdersBy = { "name", "description", "category", "area" };
                if (!acceptedOrdersBy.Contains(orderBy))
                {
                    orderBy = "name";
                }
            }

            var animals = await _animalRepository.GetAnimalsAsync(orderBy);

            return Ok(animals);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AnimalPOST animalPOST)
        {
            var animalExists = await _animalRepository.DoesAnimalExist(animalPOST.ID);
            if (animalExists)
            {
                return Conflict("Animal with this ID does exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _animalRepository.AddAnimal(animalPOST);
            return Created("api/animals", animalPOST);
        }

        [HttpPut]
        [Route("{animalID}")]
        public async Task<IActionResult> UpdateAnimal(int animalID, [FromBody] AnimalPUT animalPUT)
        {
            var animalExists = await _animalRepository.DoesAnimalExist(animalID);
            if (!animalExists)
            {
                return NotFound("Animal does not exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _animalRepository.UpdateAnimal(animalID, animalPUT);
            return Ok(animalPUT);
        }

        [HttpDelete]
        [Route("{animalID}")]
        public async Task<IActionResult> DeleteAnimal(int animalID)
        {
            var animalExists = await _animalRepository.DoesAnimalExist(animalID);
            if (!animalExists)
            {
                return NotFound("Animal does not exists");
            }
            await _animalRepository.DeleteAnimal(animalID);
            return Ok("Animal was correctly removed");
        }
    }
}
