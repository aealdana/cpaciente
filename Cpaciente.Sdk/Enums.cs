namespace Cpaciente.Sdk;

public enum StaffRole
{
    Doctor,
    Nurse,
    Receptionist,
    Admin
}

public enum EncounterStatus
{
    Waiting,
    InProgress,
    Completed,
    Cancelled
}

public enum MeasurementUnit
{
    Mg,
    Mcg,
    G,
    Ml,
    Ui,
    Percent
}

public enum MedicationRoute
{
    Oral,
    Iv,
    Im,
    Subcutaneous,
    Topical,
    Sublingual,
    Rectal,
    Ophthalmic,
    Otic,
    Inhaled
}

public enum PrescriptionStatus
{
    Active,
    Completed,
    Cancelled
}

public enum MedicalOrderType
{
    Laboratory,
    Imaging,
    Referral,
    Procedure
}

public enum MedicalOrderStatus
{
    Pending,
    Completed,
    Cancelled
}

public enum DiagnosisType
{
    Primary,
    Secondary,
    Presumptive,
    Confirmed
}

public enum ConditionStatus
{
    Active,
    Resolved
}

public enum AllergySeverity
{
    Mild,
    Moderate,
    Severe
}
