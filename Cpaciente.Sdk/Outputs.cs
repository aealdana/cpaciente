namespace Cpaciente.Sdk
{
    public sealed record EncounterHistoryOutput(
        int Id,
        string? ChiefComplaint,
        string Status,
        string? Priority,
        DateTime CreatedAt,
        DateTime? StartedAt,
        DateTime? EndedAt,
        string AttendingStaffName,
        IReadOnlyList<EncounterDiagnosisOutput> Diagnoses
    );

    public sealed record EncounterDiagnosisOutput(
        string DiseaseName,
        string DiagnosisType
    );

}
