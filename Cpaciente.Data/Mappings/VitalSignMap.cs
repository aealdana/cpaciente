using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class VitalSignMap : IEntityTypeConfiguration<VitalSign>
{
    public void Configure(EntityTypeBuilder<VitalSign> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Encounter)
            .WithOne(e => e.VitalSign)
            .HasForeignKey<VitalSign>(x => x.EncounterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.RecordedBy)
            .WithMany(s => s.RecordedVitalSigns)
            .HasForeignKey(x => x.RecordedById)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
