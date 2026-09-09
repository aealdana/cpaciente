namespace Cpaciente;

public class Patient
{
    public int Id { get; set; }
    public string DocumentId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; }
    public string? Gender { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();
    public ICollection<PatientCondition> Conditions { get; set; } = new List<PatientCondition>();
    public ICollection<PatientAllergy> Allergies { get; set; } = new List<PatientAllergy>();
}
