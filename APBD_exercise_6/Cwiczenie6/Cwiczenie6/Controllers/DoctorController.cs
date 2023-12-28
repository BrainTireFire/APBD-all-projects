using Cwiczenie6.DTOs;
using Cwiczenie6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctors();
            return Ok(doctors.Select(e => new GetDoctorDTO
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Prescriptions = e.Prescriptions.Select(e => new GetPerscriptionDTO
                {
                    FirstName = e.Patient.FirstName,
                    LastName = e.Patient.LastName,
                    Date = e.Date,
                    DueDate = e.DueDate,
                }).ToList()
            }));
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(idDoctor);
            if (doctor == null)
            {
                return NotFound("Doctor does not exists");
            }

            await _doctorService.DeleteDoctor(doctor);
            return Ok("Doctor was correctly removed");
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDTO doctorDTO)
        {
            var doctorExisting = await _doctorService.GetDoctorByNameAndSurnameAndEmailAsync(doctorDTO);
            if (doctorExisting != null)
            {
                return BadRequest("Doctor does exist");
            }

            await _doctorService.AddDoctor(doctorDTO);
            return Created("Doctor ", doctorDTO);
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> EditDoctor(int idDoctor,[FromBody] DoctorDTO doctorDTO)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(idDoctor);
            if (doctor == null)
            {
                return NotFound("Doctor does not exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _doctorService.EditDoctor(idDoctor, doctorDTO);
            return Ok("Doctor was correctly edited");
        }
    }
}
