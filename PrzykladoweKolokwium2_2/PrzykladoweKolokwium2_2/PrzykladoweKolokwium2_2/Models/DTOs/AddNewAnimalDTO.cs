using System.ComponentModel.DataAnnotations;

namespace PrzykladoweKolokwium2_2.Models.DTOs
{
    public class AddNewAnimalDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string AnimalClass { get; set; } = null!;
        [Required]
        public DateTime AdmissionDate { get; set; }
        [Required]
        public int OwnerID { get; set; }
        [Required]
        public ICollection<AddNewAnimalProcedureDTO> Procedures { get; set; } = new List<AddNewAnimalProcedureDTO>();
    }
}
