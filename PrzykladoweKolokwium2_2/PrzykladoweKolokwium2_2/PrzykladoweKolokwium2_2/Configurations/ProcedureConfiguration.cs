using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_2.Models;

namespace PrzykladoweKolokwium2_2.Configurations
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("Procedure");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Description).HasMaxLength(100);

            builder.HasData(new List<Procedure>()
            {
                new Procedure
                {
                    ID = 1,
                    Name = "Endoscopy",
                    Description = "Lorem ipsum ..."
                },
                new Procedure
                {
                    ID = 2,
                    Name = "Cholecystectomy",
                    Description = "Lorem ipsum ..."
                }
            });
        }
    }
}
