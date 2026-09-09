using Cpaciente.Data;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPaciente.Handlers.Queries;

public sealed class GetPatientEncountersQueryHandler
    : IRequestHandler<GetPatientEncountersQuery, List<EncounterHistoryOutput>>
{
    private readonly CpacienteDbContext _context;

    public GetPatientEncountersQueryHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<List<EncounterHistoryOutput>> Handle(GetPatientEncountersQuery request, CancellationToken cancellationToken)
    {        
        var patientExists = await _context.Patients.AsNoTracking().AnyAsync(p => p.Id == request.PatientId, cancellationToken);

        if (!patientExists)
        {
            throw new KeyNotFoundException($"No se encontro el paciente con id {request.PatientId}.");
        }

        return await _context.Encounters
            .AsNoTracking()
            .Where(e => e.PatientId == request.PatientId)
            .OrderByDescending(e => e.CreatedAt)
            .Select(e => new EncounterHistoryOutput(
                e.Id,
                e.ChiefComplaint,
                e.Status.ToString(),
                e.Priority,
                e.CreatedAt,
                e.StartedAt,
                e.EndedAt,
                e.AttendingStaff.FullName,
                e.Diagnoses
                    .Select(d => new EncounterDiagnosisOutput(d.Disease.Name, d.DiagnosisType.ToString()))
                    .ToList()))
            .ToListAsync(cancellationToken);
    }   
}
