namespace PrzykladoweKolokwium2_1.Models
{
    public class OrderPastry
    {
        public int OrderID { get; set; }
        public int PastryID { get; set; }
        public int Amount { get; set; }
        public string? Comments { get; set; }
        public virtual Pastry Pastry { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
