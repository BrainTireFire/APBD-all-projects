using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_2.Models
{
    [Table("Procedure")]
    public class Procedure
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(100)]
        public string Description { get; set; } = null!;
        public virtual ICollection<ProcedureAnimal> ProcedureAnimals { get; set; } = new List<ProcedureAnimal>();
    }
}
