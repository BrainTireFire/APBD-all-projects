using System.ComponentModel.DataAnnotations;

namespace PrzykladoweKolokwium2_1.Models.DTOs
{
    public class NewOrderDTO
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime AcceptedAt { get; set; }
        [MaxLength(300)]
        public string? Comments { get; set; } = null;
        [Required]
        public ICollection<NewOrderPastryDTO> Pastries { get; set; } = new List<NewOrderPastryDTO>();
    }
}
