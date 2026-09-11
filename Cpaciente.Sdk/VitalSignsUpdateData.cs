namespace Cpaciente.Sdk;

// Todos los campos son opcionales a proposito: PATCH solo actualiza
// los valores que vengan distintos de null, el resto queda intacto.
public sealed record VitalSignsUpdateData(
    decimal? Height,
    decimal? Weight,
    decimal? Temperature,
    decimal? SystolicPressure,
    decimal? DiastolicPressure,
    decimal? OxygenSaturation,
    decimal? RespiratoryRate,
    decimal? HeartRate
);
