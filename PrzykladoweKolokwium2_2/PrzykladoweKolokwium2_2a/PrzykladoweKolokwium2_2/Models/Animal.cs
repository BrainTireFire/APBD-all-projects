using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_2.Models
{
    [Table("Animal")]
    public class Animal
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public int OwnerID { get; set; }
        public int AnimalClassID { get; set; }
        [ForeignKey(nameof(OwnerID))]
        public virtual Owner Owner { get; set; } = null!;
        [ForeignKey(nameof(AnimalClassID))]
        public virtual AnimalClass AnimalClass { get; set; } = null!;
        public virtual ICollection<ProcedureAnimal> ProcedureAnimals { get; set; } = new List<ProcedureAnimal>();
    }
}
