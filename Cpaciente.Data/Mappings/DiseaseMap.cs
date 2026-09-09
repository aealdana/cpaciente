using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class DiseaseMap : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code).HasMaxLength(ClinicaGlobalValues.CodeSize);
        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.Name).HasMaxLength(ClinicaGlobalValues.NameSize);
    }
}
