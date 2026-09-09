using Cpaciente.Sdk;

namespace Cpaciente;

public class Medication
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Presentation { get; set; }
    public decimal? ConcentrationAmount { get; set; }
    public MeasurementUnit? ConcentrationUnit { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
