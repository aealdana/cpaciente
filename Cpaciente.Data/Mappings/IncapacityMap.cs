using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class IncapacityMap : IEntityTypeConfiguration<Incapacity>
{
    public void Configure(EntityTypeBuilder<Incapacity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Justification).HasMaxLength(ClinicaGlobalValues.DescriptionSize);

        builder.HasOne(x => x.Encounter)
            .WithOne(e => e.Incapacity)
            .HasForeignKey<Incapacity>(x => x.EncounterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.IssuedBy)
            .WithMany(s => s.IssuedIncapacities)
            .HasForeignKey(x => x.IssuedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
