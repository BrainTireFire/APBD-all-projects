using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Cwiczenie6.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");

            builder.HasKey(e => e.IdPatient);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);


            builder.HasData(new List<Patient>()
            {
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Andrzej",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Parse("1998-05-13"),
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Marcin",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Parse("2000-07-15"),
                },
            });
        }

    }
}
