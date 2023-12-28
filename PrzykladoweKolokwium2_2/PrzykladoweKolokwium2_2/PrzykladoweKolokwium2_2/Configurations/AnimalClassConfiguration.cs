using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_2.Models;

namespace PrzykladoweKolokwium2_2.Configurations
{
    public class AnimalClassConfiguration : IEntityTypeConfiguration<AnimalClass>
    {
        public void Configure(EntityTypeBuilder<AnimalClass> builder)
        {
            builder.ToTable("Animal_Class");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasData(new List<AnimalClass>()
            {
                new AnimalClass {
                    ID = 1,
                    Name = "Mammal"
                },
                new AnimalClass {
                    ID = 2,
                    Name = "Bird"
                }
            });
        }
    }
}
