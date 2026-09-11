using Cpaciente; // AJUSTA este using al namespace real de tus entidades/enums
using Cpaciente.Commands;
using Cpaciente.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Cpaciente.Sdk;

namespace CPaciente.Handlers.Commands;

public sealed class StartEncounterCommandHandler : IRequestHandler<StartEncounterCommand>
{
    private readonly CpacienteDbContext _context;

    public StartEncounterCommandHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task Handle(StartEncounterCommand request, CancellationToken cancellationToken)
    {
        var encounter = await _context.Encounters
            .FirstOrDefaultAsync(e => e.Id == request.EncounterId, cancellationToken);

        if (encounter is null)
        {
            throw new KeyNotFoundException($"No se encontro la consulta con id {request.EncounterId}.");
        }

        if (encounter.Status != EncounterStatus.Waiting)
        {
            throw new InvalidOperationException(
                $"Solo se puede iniciar una consulta en estado Waiting. Estado actual: {encounter.Status}.");
        }

        encounter.Status = EncounterStatus.InProgress;
        encounter.StartedAt = DateTime.UtcNow;
        encounter.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
