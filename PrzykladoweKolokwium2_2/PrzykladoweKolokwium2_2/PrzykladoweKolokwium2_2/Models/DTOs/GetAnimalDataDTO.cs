namespace PrzykladoweKolokwium2_2.Models.DTOs
{
    public class GetAnimalDataDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string AnimalClass { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public GetAnimalDataOwnerDTO Owner { get; set; } = null!;
        public ICollection<GetAnimalDataProcedureDTO> Procedures { get; set; } = new List<GetAnimalDataProcedureDTO>();
    }
}
