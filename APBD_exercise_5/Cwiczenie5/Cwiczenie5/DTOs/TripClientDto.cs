namespace Cwiczenie5.DTOs
{
    public class TripClientDto
    {
        public int IdClient { get; set; }
        public int IdTrip { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
