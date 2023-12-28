using System.Collections;

namespace Cwiczenie5.DTOs
{
    public class TripWithAdditionalData
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int MaxPeople { get; set; }
        public IEnumerable<ContryName> Countries { get; set; } = new List<ContryName>();
        public IEnumerable<ClientFullName> Clients { get; set; } = new List<ClientFullName>();
    }
}
