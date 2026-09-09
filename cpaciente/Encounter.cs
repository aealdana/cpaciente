using Cpaciente.Sdk;

namespace Cpaciente;

public class Encounter
{
    public int Id { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public int AttendingStaffId { get; set; }
    public Staff AttendingStaff { get; set; } = null!;

    public string? ChiefComplaint { get; set; }
    public string? Symptoms { get; set; }
    public string? PhysicalExamination { get; set; }
    public string? Notes { get; set; }
    public EncounterStatus Status { get; set; } = EncounterStatus.Waiting;
    public string? Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public DateTime? DeletedAt { get; set; }

    public VitalSign? VitalSign { get; set; }
    public Incapacity? Incapacity { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public ICollection<MedicalOrder> MedicalOrders { get; set; } = new List<MedicalOrder>();
    public ICollection<EncounterDiagnosis> Diagnoses { get; set; } = new List<EncounterDiagnosis>();
}
