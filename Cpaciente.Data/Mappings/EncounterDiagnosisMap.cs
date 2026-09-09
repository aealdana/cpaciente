using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class EncounterDiagnosisMap : IEntityTypeConfiguration<EncounterDiagnosis>
{
    public void Configure(EntityTypeBuilder<EncounterDiagnosis> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Notes).HasMaxLength(ClinicaGlobalValues.DescriptionSize);

        builder.HasOne(x => x.Encounter)
            .WithMany(e => e.Diagnoses)
            .HasForeignKey(x => x.EncounterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Disease)
            .WithMany(d => d.EncounterDiagnoses)
            .HasForeignKey(x => x.DiseaseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
