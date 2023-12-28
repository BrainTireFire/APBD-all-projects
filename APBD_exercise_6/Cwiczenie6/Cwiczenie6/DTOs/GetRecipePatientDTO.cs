namespace Cwiczenie6.DTOs
{
    public class GetRecipePatientDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthdate { get; set; }
    }
}
