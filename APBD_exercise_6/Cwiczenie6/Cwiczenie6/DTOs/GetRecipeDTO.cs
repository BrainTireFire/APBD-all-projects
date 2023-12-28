namespace Cwiczenie6.DTOs
{
    public class GetRecipeDTO
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public GetRecipeDoctorDTO Doctor { get; set; } = null!;
        public GetRecipePatientDTO Patient { get; set; } = null!;
        public ICollection<GetRecipeMedicamentsDTO> Medicaments { get; set; } = new List<GetRecipeMedicamentsDTO>();
    }
}
