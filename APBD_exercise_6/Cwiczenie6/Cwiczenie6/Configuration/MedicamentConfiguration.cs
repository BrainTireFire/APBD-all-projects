using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie6.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.ToTable("Medicament");

            builder.HasKey(e => e.IdMedicament);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.Type).HasMaxLength(100);

            builder.HasData(new List<Medicament>()
            {
                new Medicament
                {
                     IdMedicament = 1,
                     Name = "Lek 1",
                     Description = "Opis leku 1",
                     Type = "A",
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Lek 2",
                     Description = "Opis leku 2",
                     Type = "B",
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Lek 3",
                    Description = "Opis leku 3",
                    Type = "A",
                },
            });
        }
    }
}
