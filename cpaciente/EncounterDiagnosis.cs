using Cpaciente.Sdk;

namespace Cpaciente;

public class EncounterDiagnosis
{
    public int Id { get; set; }

    public int EncounterId { get; set; }
    public Encounter Encounter { get; set; } = null!;

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; } = null!;

    public DiagnosisType DiagnosisType { get; set; }
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
