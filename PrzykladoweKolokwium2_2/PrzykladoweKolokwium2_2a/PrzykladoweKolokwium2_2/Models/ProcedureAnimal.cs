using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_2.Models
{
    [PrimaryKey(nameof(ProcedureID),nameof(AnimalID),nameof(Date))]
    [Table("Procedure_Animal")]
    public class ProcedureAnimal
    {
        public int ProcedureID { get; set; }
        public int AnimalID { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey(nameof(ProcedureID))]
        public virtual Procedure Procedure { get; set; } = null!;
        [ForeignKey(nameof(AnimalID))]
        public virtual Animal Animal { get; set; } = null!;
    }
}
