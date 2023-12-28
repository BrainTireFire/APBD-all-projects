using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_2.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
