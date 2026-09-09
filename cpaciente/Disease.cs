namespace Cpaciente;

public class Disease
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsChronic { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<EncounterDiagnosis> EncounterDiagnoses { get; set; } = new List<EncounterDiagnosis>();
    public ICollection<PatientCondition> PatientConditions { get; set; } = new List<PatientCondition>();
}
