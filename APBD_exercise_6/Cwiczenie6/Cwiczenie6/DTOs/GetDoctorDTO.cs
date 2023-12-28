using Cwiczenie6.Models;

namespace Cwiczenie6.DTOs
{
    public class GetDoctorDTO
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<GetPerscriptionDTO> Prescriptions { get; set; } = null!;
    }
}
