using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrzykladoweKolokwium2_1.Models;

namespace PrzykladoweKolokwium2_1.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.ID);

            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(120);

            builder.HasData(new List<Employee>
            {
                new Employee {
                    ID = 1,
                    FirstName = "Adam",
                    LastName = "Nowak"
                },
                new Employee {
                    ID = 2,
                    FirstName = "Aleksandra",
                    LastName = "Wiśniewska"
                }
            });
        }
    }
}
