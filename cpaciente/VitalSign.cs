namespace Cpaciente;

public class VitalSign
{
    public int Id { get; set; }

    public int EncounterId { get; set; }
    public Encounter Encounter { get; set; } = null!;

    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Temperature { get; set; }
    public decimal? SystolicPressure { get; set; }
    public decimal? DiastolicPressure { get; set; }
    public decimal? OxygenSaturation { get; set; }
    public decimal? RespiratoryRate { get; set; }
    public decimal? HeartRate { get; set; }

    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    public int? RecordedById { get; set; }
    public Staff? RecordedBy { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
