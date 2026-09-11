namespace Cpaciente.Sdk;

public sealed record PatientCreationData(
    string DocumentId,
    string FirstName,
    string LastName,
    DateOnly BirthDate,
    string? Gender,
    string? Phone,
    string? Email,
    string? Address,
    string? EmergencyContactName,
    string? EmergencyContactPhone
);
