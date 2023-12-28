namespace Cwiczenie6.DTOs
{
    public class GetPerscriptionDTO
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
