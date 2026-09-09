using Cpaciente.Sdk;
namespace Cpaciente;

public class PatientCondition
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; } = null!;

    public int? EncounterId { get; set; }
    public Encounter? Encounter { get; set; }

    public DateOnly DiagnosedDate { get; set; }
    public ConditionStatus Status { get; set; } = ConditionStatus.Active;
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
