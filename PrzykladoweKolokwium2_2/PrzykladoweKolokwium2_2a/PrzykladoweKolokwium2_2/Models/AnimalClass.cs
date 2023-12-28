using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_2.Models
{
    [Table("Animal_Class")]
    public class AnimalClass
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
