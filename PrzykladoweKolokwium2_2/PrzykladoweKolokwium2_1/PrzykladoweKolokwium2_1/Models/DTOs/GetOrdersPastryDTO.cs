namespace PrzykladoweKolokwium2_1.Models.DTOs
{
    public class GetOrdersPastryDTO
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
