using Cpaciente.Data;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPaciente.Handlers.Queries;

public sealed class GetAllergiesQueryHandler : IRequestHandler<GetAllergiesQuery, List<AllergyOutput>>
{
    private readonly CpacienteDbContext _context;

    public GetAllergiesQueryHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<List<AllergyOutput>> Handle(GetAllergiesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Allergies
            .AsNoTracking()
            .OrderBy(a => a.Name)
            .Select(a => new AllergyOutput(a.Id, a.Name, a.Type))
            .ToListAsync(cancellationToken);
    }
}
