using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class PatientMap : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DocumentId).HasMaxLength(ClinicaGlobalValues.CodeSize);
        builder.HasIndex(x => x.DocumentId).IsUnique();

        builder.Property(x => x.FirstName).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.LastName).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.Gender).HasMaxLength(ClinicaGlobalValues.ShortTextSize);
        builder.Property(x => x.Phone).HasMaxLength(ClinicaGlobalValues.PhoneSize);
        builder.Property(x => x.Email).HasMaxLength(ClinicaGlobalValues.ContactSize);
        builder.Property(x => x.Address).HasMaxLength(ClinicaGlobalValues.DescriptionSize);
        builder.Property(x => x.EmergencyContactName).HasMaxLength(ClinicaGlobalValues.NameSize);
        builder.Property(x => x.EmergencyContactPhone).HasMaxLength(ClinicaGlobalValues.PhoneSize);

        // Los registros con soft-delete quedan ocultos por defecto en todas las consultas.
        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}
