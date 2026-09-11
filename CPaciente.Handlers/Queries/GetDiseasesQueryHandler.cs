using Cpaciente.Data;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPaciente.Handlers.Queries;

public sealed class GetDiseasesQueryHandler : IRequestHandler<GetDiseasesQuery, List<DiseaseOutput>>
{
    private readonly CpacienteDbContext _context;

    public GetDiseasesQueryHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task<List<DiseaseOutput>> Handle(GetDiseasesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Diseases
            .AsNoTracking()
            .OrderBy(d => d.Name)
            .Select(d => new DiseaseOutput(d.Id, d.Code, d.Name, d.IsChronic))
            .ToListAsync(cancellationToken);
    }
}
