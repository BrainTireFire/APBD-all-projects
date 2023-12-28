using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykladoweKolokwium2_1.Models
{
    [PrimaryKey(nameof(OrderID), nameof(PastryID))]
    [Table("OrderPastry")]
    public class OrderPastry
    {
        public int OrderID { get; set; }
        public int PastryID { get; set; }
        public int Amount { get; set; }
        [MaxLength(300)]
        public string? Comments { get; set; }
        [ForeignKey(nameof(PastryID))]
        public virtual Pastry Pastry { get; set; } = null!;
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = null!;
    }
}
