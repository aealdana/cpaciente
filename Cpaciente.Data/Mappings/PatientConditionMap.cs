using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class PatientConditionMap : IEntityTypeConfiguration<PatientCondition>
{
    public void Configure(EntityTypeBuilder<PatientCondition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Notes).HasMaxLength(ClinicaGlobalValues.DescriptionSize);

        builder.HasOne(x => x.Patient)
            .WithMany(p => p.Conditions)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Disease)
            .WithMany(d => d.PatientConditions)
            .HasForeignKey(x => x.DiseaseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Nullable: la condicion puede no venir de un encounter (ej. historial externo).
        builder.HasOne(x => x.Encounter)
            .WithMany()
            .HasForeignKey(x => x.EncounterId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
