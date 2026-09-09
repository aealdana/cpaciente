using Cpaciente.Sdk;

namespace Cpaciente;

public class Staff
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public StaffRole Role { get; set; }
    public string? LicenseNumber { get; set; }
    public string? Specialty { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Encounter> AttendedEncounters { get; set; } = new List<Encounter>();
    public ICollection<VitalSign> RecordedVitalSigns { get; set; } = new List<VitalSign>();
    public ICollection<Prescription> PrescribedPrescriptions { get; set; } = new List<Prescription>();
    public ICollection<MedicalOrder> OrderedMedicalOrders { get; set; } = new List<MedicalOrder>();
    public ICollection<Incapacity> IssuedIncapacities { get; set; } = new List<Incapacity>();
}
