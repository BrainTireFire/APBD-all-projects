using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(120);

            builder.HasData(new List<Client>
            {
                new Client { 
                    ID = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Client {
                    ID = 2,
                    FirstName = "Anna",
                    LastName = "Nowak"
                }
            });
        }
    }
}
