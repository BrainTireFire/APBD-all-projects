using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Configurations
{
    public class OrderPastryConfiguration : IEntityTypeConfiguration<OrderPastry>
    {
        public void Configure(EntityTypeBuilder<OrderPastry> builder)
        {
            builder.ToTable("Order_Pastry");

            builder.HasKey(e => new { e.OrderID, e.PastryID });

            builder.Property(e => e.Comments).HasMaxLength(300);

            builder.HasOne(e => e.Pastry)
                .WithMany(e => e.OrderPastries)
                .HasForeignKey(e => e.PastryID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Order)
                .WithMany(e => e.OrderPastries)
                .HasForeignKey(e => e.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<OrderPastry>
            {
                new OrderPastry
                {
                    OrderID = 1,
                    PastryID = 1,
                    Amount = 3,
                },
                new OrderPastry
                {
                    OrderID = 1,
                    PastryID = 3,
                    Amount = 4,
                    Comments = "Lorem ipsum ..."
                },
                new OrderPastry
                {
                    OrderID = 2,
                    PastryID = 2,
                    Amount = 2
                },
                new OrderPastry
                {
                    OrderID = 2,
                    PastryID = 1,
                    Amount = 12
                }
            });
        }
    }
}
