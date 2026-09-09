using Microsoft.EntityFrameworkCore;

namespace Cpaciente.Data;

public class ClinicaDbContext : DbContext
{
    public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options) { }

    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Staff> Staff => Set<Staff>();
    public DbSet<Encounter> Encounters => Set<Encounter>();
    public DbSet<VitalSign> VitalSigns => Set<VitalSign>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<Prescription> Prescriptions => Set<Prescription>();
    public DbSet<MedicalOrder> MedicalOrders => Set<MedicalOrder>();
    public DbSet<Incapacity> Incapacities => Set<Incapacity>();
    public DbSet<Disease> Diseases => Set<Disease>();
    public DbSet<EncounterDiagnosis> EncounterDiagnoses => Set<EncounterDiagnosis>();
    public DbSet<PatientCondition> PatientConditions => Set<PatientCondition>();
    public DbSet<Allergy> Allergies => Set<Allergy>();
    public DbSet<PatientAllergy> PatientAllergies => Set<PatientAllergy>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
