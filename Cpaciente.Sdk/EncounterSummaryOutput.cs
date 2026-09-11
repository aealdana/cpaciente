namespace Cpaciente.Sdk;

public sealed record EncounterSummaryOutput(
    int Id,
    int PatientId,
    string PatientName,
    string? ChiefComplaint,
    string? Priority,
    string Status,
    DateTime CreatedAt
);
