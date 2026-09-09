using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class EncounterMap : IEntityTypeConfiguration<Encounter>
{
    public void Configure(EntityTypeBuilder<Encounter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Priority).HasMaxLength(ClinicaGlobalValues.ShortTextSize);

        builder.HasOne(x => x.Patient)
            .WithMany(p => p.Encounters)
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AttendingStaff)
            .WithMany(s => s.AttendedEncounters)
            .HasForeignKey(x => x.AttendingStaffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}
