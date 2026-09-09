using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class StaffMap : IEntityTypeConfiguration<Staff>
{
    public void Configure(EntityTypeBuilder<Staff> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.LicenseNumber).HasMaxLength(ClinicaGlobalValues.CodeSize);
        builder.Property(x => x.Specialty).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.Phone).HasMaxLength(ClinicaGlobalValues.PhoneSize);
        builder.Property(x => x.Email).HasMaxLength(ClinicaGlobalValues.ContactSize);
    }
}
