using Cpaciente.Sdk;

namespace Cpaciente;

public class PatientAllergy
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int AllergyId { get; set; }
    public Allergy Allergy { get; set; } = null!;

    public AllergySeverity Severity { get; set; }
    public string? Reaction { get; set; }
    public DateOnly? IdentifiedDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
