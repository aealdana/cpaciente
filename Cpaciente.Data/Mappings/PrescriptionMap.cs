using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class PrescriptionMap : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Strength).HasMaxLength(ClinicaGlobalValues.ShortTextSize);
        builder.Property(x => x.Dosage).HasMaxLength(ClinicaGlobalValues.ShortTextSize);
        builder.Property(x => x.Frequency).HasMaxLength(ClinicaGlobalValues.ShortTextSize);
        builder.Property(x => x.Duration).HasMaxLength(ClinicaGlobalValues.ShortTextSize);

        builder.HasOne(x => x.Encounter)
            .WithMany(e => e.Prescriptions)
            .HasForeignKey(x => x.EncounterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Medication)
            .WithMany(m => m.Prescriptions)
            .HasForeignKey(x => x.MedicationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PrescribedBy)
            .WithMany(s => s.PrescribedPrescriptions)
            .HasForeignKey(x => x.PrescribedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
