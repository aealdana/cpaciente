namespace Cpaciente;

public class Allergy
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<PatientAllergy> PatientAllergies { get; set; } = new List<PatientAllergy>();
}
