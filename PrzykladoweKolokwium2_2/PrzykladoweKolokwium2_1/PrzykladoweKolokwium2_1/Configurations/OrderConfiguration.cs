using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.Comments).HasMaxLength(300);

            builder.HasOne(e => e.Client)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ClientID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Order>
            {
                new Order
                {
                    ID = 1,
                    AcceptedAt = DateTime.Parse("2023-05-28"),
                    FulfilledAt = DateTime.Parse("2023-05-29"),
                    Comments = "Lorem ipsum ...",
                    ClientID = 1,
                    EmployeeID = 2
                },
                new Order
                {
                    ID = 2,
                    AcceptedAt = DateTime.Parse("2023-05-31"),
                    FulfilledAt = DateTime.Parse("2023-06-01"),
                    Comments = "Lorem ipsum ...",
                    ClientID = 1,
                    EmployeeID = 1
                },
                new Order
                {
                    ID = 3,
                    AcceptedAt = DateTime.Parse("2023-06-01"),
                    FulfilledAt = null,
                    Comments = null,
                    ClientID = 2,
                    EmployeeID = 1
                }
            });
        }
    }
}
