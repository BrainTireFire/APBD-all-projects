using System.ComponentModel.DataAnnotations;

namespace PrzykladoweKolokwium2_2.Models.DTOs
{
    public class AddNewAnimalProcedureDTO
    {
        [Required]
        public int ProcedureID { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
