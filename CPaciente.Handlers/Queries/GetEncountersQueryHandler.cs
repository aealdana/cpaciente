using Cpaciente; // AJUSTA este using al namespace real de tus entidades/enums
using Cpaciente.Data;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Queries;

public sealed class GetEncountersQueryHandler : IRequestHandler<GetEncountersQuery, List<EncounterSummaryOutput>>
{
    private readonly CpacienteDbContext _context;

    public GetEncountersQueryHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<List<EncounterSummaryOutput>> Handle(GetEncountersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Encounters.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            if (!Enum.TryParse<EncounterStatus>(request.Status, ignoreCase: true, out var status))
            {
                throw new ArgumentException(
                    $"Estado invalido: {request.Status}. Valores validos: {string.Join(", ", Enum.GetNames<EncounterStatus>())}.");
            }

            query = query.Where(e => e.Status == status);
        }

        return await query
            .OrderBy(e => e.CreatedAt)
            .Select(e => new EncounterSummaryOutput(
                e.Id,
                e.PatientId,
                e.Patient.FirstName + " " + e.Patient.LastName,
                e.ChiefComplaint,
                e.Priority,
                e.Status.ToString(),
                e.CreatedAt))
            .ToListAsync(cancellationToken);
    }
}
