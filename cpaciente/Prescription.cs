using Cpaciente.Sdk;

namespace Cpaciente;

public class Prescription
{
    public int Id { get; set; }

    public int EncounterId { get; set; }
    public Encounter Encounter { get; set; } = null!;

    public int MedicationId { get; set; }
    public Medication Medication { get; set; } = null!;

    public string? Strength { get; set; }
    public string? Dosage { get; set; }
    public string? Frequency { get; set; }
    public string? Duration { get; set; }
    public MedicationRoute Route { get; set; }
    public int? Quantity { get; set; }
    public PrescriptionStatus Status { get; set; } = PrescriptionStatus.Active;

    public int PrescribedById { get; set; }
    public Staff PrescribedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
