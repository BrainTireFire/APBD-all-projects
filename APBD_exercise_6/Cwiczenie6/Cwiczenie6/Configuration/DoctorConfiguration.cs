using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Cwiczenie6.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.ToTable("Doctor");

            builder.HasKey(e => e.IdDoctor);

            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.Email).HasMaxLength(100);


            builder.HasData(new List<Doctor>()
            {
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Tomek",
                    LastName = "Kowalski",
                    Email = "tomekkowalski@gmail.com",
                },
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Michal",
                    LastName = "Kowalski",
                    Email = "Michalkowalski@gmail.com",
                },
            });
        }
    }
}
