namespace Cwiczenie5.DTOs
{
    public class CreateClientWithTrip
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telephone { get; set; } = null!;

        public string Pesel { get; set; } = null!;

        public int TripID { get; set; }

        public string TripName { get; set; } = null!;

        public DateTime? PaymentDate { get; set; }

    }
}
