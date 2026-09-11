using Microsoft.AspNetCore.Identity;

namespace Cpaciente.Data;

// Cada usuario del sistema corresponde a un Staff existente (1 a 1).
public sealed class ApplicationUser : IdentityUser
{
    public int StaffId { get; set; }
}
