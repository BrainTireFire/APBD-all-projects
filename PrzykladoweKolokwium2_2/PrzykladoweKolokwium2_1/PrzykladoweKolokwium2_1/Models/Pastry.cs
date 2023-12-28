namespace PrzykladoweKolokwium2_1.Models
{
    public class Pastry
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Type { get; set; } = null!;
        public virtual ICollection<OrderPastry> OrderPastries { get; set; } = new List<OrderPastry>();
    }
}
