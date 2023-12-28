using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Configurations
{
    public class PastryConfiguration : IEntityTypeConfiguration<Pastry>
    {
        public void Configure(EntityTypeBuilder<Pastry> builder)
        {
            builder.ToTable("Pastry");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Name).HasMaxLength(150);
            builder.Property(e => e.Price).HasPrecision(10, 2);
            builder.Property(e => e.Type).HasMaxLength(40);

            builder.HasData(new List<Pastry>
            {
                new Pastry
                {
                    ID = 1,
                    Name = "Drożdzówka",
                    Price = 3.3M,
                    Type = "A"
                },
                new Pastry
                {
                    ID = 2,
                    Name = "Babka cytrynowa",
                    Price = 21.23M,
                    Type = "B"
                },
                new Pastry
                {
                    ID = 3,
                    Name = "Jagodzianka",
                    Price = 7.2M,
                    Type = "A"
                }
            });
        }
    }
}
