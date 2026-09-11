using Cpaciente; // AJUSTA este using al namespace real de tu entidad Staff
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cpaciente.Data.Mappings;

internal class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // Un Staff no puede tener mas de una cuenta de login.
        builder.HasIndex(u => u.StaffId).IsUnique();

        builder.HasOne<Staff>()
            .WithOne()
            .HasForeignKey<ApplicationUser>(u => u.StaffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
