using Cpaciente.Sdk;

namespace Cpaciente;

public class MedicalOrder
{
    public int Id { get; set; }

    public int EncounterId { get; set; }
    public Encounter Encounter { get; set; } = null!;

    public MedicalOrderType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public MedicalOrderStatus Status { get; set; } = MedicalOrderStatus.Pending;

    public int OrderedById { get; set; }
    public Staff OrderedBy { get; set; } = null!;

    public string? Result { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
