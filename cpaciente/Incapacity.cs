namespace Cpaciente;

public class Incapacity
{
    public int Id { get; set; }

    public int EncounterId { get; set; }
    public Encounter Encounter { get; set; } = null!;

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Justification { get; set; }

    public int IssuedById { get; set; }
    public Staff IssuedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
