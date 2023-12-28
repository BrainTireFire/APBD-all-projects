using Cwiczenie6.DTOs;
using Cwiczenie6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{IdPrescription}")]
        public async Task<IActionResult> GetRecipeData(int IdPrescription)
        {
            if (!await _recipeService.DoesPrescriptionExist(IdPrescription))
                return NotFound($"Prescription with given ID - {IdPrescription} doesn't exist");

            var recipe = await _recipeService.GetPrescription(IdPrescription);

            return Ok(new GetRecipeDTO
            {
                IdPrescription = recipe.IdPrescription,
                Date = recipe.Date,
                DueDate = recipe.DueDate,
                Doctor = new GetRecipeDoctorDTO
                {
                    FirstName = recipe.Doctor.FirstName,
                    LastName = recipe.Doctor.LastName,
                    Email = recipe.Doctor.Email
                },
                Patient = new GetRecipePatientDTO 
                { 
                    FirstName = recipe.Patient.FirstName, 
                    LastName = recipe.Patient.LastName,
                    Birthdate = recipe.Patient.Birthdate
                },
                Medicaments = recipe.PrescriptionMedicaments.Select(e => new GetRecipeMedicamentsDTO
                {
                    Name = e.Medicament.Name,
                    Description = e.Medicament.Description,
                    Type = e.Medicament.Type
                }).ToList()
            });
        }

    }
}
