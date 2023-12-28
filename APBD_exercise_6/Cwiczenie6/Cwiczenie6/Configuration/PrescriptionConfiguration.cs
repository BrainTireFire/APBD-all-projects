using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cwiczenie6.Configuration
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");

            builder.HasKey(e => e.IdPrescription);

            builder.Property(e => e.Date).HasColumnType("datetime");
            builder.Property(e => e.DueDate).HasColumnType("datetime");

            builder.HasOne(e => e.Doctor)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Patient)
                .WithMany(e => e.Prescriptions)
                .HasForeignKey(e => e.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Prescription>()
            {
                new Prescription
                {
                     IdPrescription = 1,
                     Date = DateTime.Parse("1990-01-14"),
                     DueDate = DateTime.Parse("1998-05-13"),
                     IdDoctor = 1,
                     IdPatient = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Parse("2000-01-14"),
                    DueDate = DateTime.Parse("2002-05-13"),
                    IdDoctor = 1,
                    IdPatient = 2
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = DateTime.Parse("2001-01-14"),
                    DueDate = DateTime.Parse("2003-05-13"),
                    IdDoctor = 2,
                    IdPatient = 1
                },
            });
        }
    }
}
