using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_1.Models
{
    [Table("Pastry")]
    public class Pastry
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [Precision(10, 2)]
        public decimal Price { get; set; }
        [MaxLength(40)]
        public string Type { get; set; } = null!;
        public virtual ICollection<OrderPastry> OrderPastries { get; set; } = new List<OrderPastry>();
    }
}
