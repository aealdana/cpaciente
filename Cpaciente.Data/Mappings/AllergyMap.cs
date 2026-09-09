using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class AllergyMap : IEntityTypeConfiguration<Allergy>
{
    public void Configure(EntityTypeBuilder<Allergy> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.Type).HasMaxLength(ClinicaGlobalValues.ShortTextSize);
    }
}
