using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class MedicalOrderMap : IEntityTypeConfiguration<MedicalOrder>
{
    public void Configure(EntityTypeBuilder<MedicalOrder> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.Description).HasMaxLength(ClinicaGlobalValues.DescriptionSize);
        builder.Property(x => x.Result).HasMaxLength(ClinicaGlobalValues.DescriptionSize);

        builder.HasOne(x => x.Encounter)
            .WithMany(e => e.MedicalOrders)
            .HasForeignKey(x => x.EncounterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.OrderedBy)
            .WithMany(s => s.OrderedMedicalOrders)
            .HasForeignKey(x => x.OrderedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
