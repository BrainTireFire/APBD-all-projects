using System.ComponentModel.DataAnnotations;

namespace Exercise3.Models.DTOs
{
    public class AnimalPOST
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(185, MinimumLength = 5)]
        public string Name { get; set; } = String.Empty;
        [StringLength(185, MinimumLength = 5)]
        public string? Description { get; set; } = null;
        [Required]
        [StringLength(185, MinimumLength = 5)]
        public string Category { get; set; } = String.Empty;
        [Required]
        [StringLength(185, MinimumLength = 5)]
        public string Area { get; set; } = String.Empty;
    }
}
