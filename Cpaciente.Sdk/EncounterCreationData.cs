namespace Cpaciente.Sdk;

public sealed record EncounterCreationData(
    int AttendingStaffId,
    string? ChiefComplaint,
    string? Symptoms,
    string? PhysicalExamination,
    string? Priority
);

public sealed record EncounterCreationOutput(
    int EncounterId,
    int VitalSignId
);
