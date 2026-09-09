using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class PatientAllergyMap : IEntityTypeConfiguration<PatientAllergy>
{
    public void Configure(EntityTypeBuilder<PatientAllergy> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Reaction).HasMaxLength(ClinicaGlobalValues.DescriptionSize);

        builder.HasOne(x => x.Patient)
            .WithMany(p => p.Allergies)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Allergy)
            .WithMany(a => a.PatientAllergies)
            .HasForeignKey(x => x.AllergyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
