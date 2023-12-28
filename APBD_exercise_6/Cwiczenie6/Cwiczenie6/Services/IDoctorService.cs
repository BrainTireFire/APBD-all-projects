using Cwiczenie6.DTOs;
using Cwiczenie6.Models;

namespace Cwiczenie6.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<Doctor> GetDoctorByIdAsync(int idDoctor);
        Task<Doctor> GetDoctorByNameAndSurnameAndEmailAsync(DoctorDTO doctorDTO);
        Task AddDoctor(DoctorDTO doctorDTO);
        Task DeleteDoctor(Doctor doctor);
        Task EditDoctor(int idDoctor, DoctorDTO doctor);
    }
}
