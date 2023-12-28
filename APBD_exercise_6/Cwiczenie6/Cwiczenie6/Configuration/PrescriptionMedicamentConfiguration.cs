using Cwiczenie6.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie6.Configuration
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");

            builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            }).HasName("Prescription_Medicament_pk");

            builder.Property(e => e.Details).HasMaxLength(100);

            builder.HasOne(e => e.Medicament)
               .WithMany(e => e.PrescriptionMedicaments)
               .HasForeignKey(e => e.IdMedicament)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Prescription)
               .WithMany(e => e.PrescriptionMedicaments)
               .HasForeignKey(e => e.IdPrescription)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<PrescriptionMedicament>()
            {
                new PrescriptionMedicament
                {
                     IdMedicament = 1,
                     IdPrescription = 1,
                     Details = "Lorem ipsum 1",
                     Dose = 100,
                },
                new PrescriptionMedicament
                {
                     IdMedicament = 2,
                     IdPrescription = 2,
                     Details = "Lorem ipsum 2",
                     Dose = 300,
                },
                new PrescriptionMedicament
                {
                     IdMedicament = 3,
                     IdPrescription = 2,
                     Details = "Lorem ipsum 3",
                     Dose = 400,
                },
            });
        }
    }
}
