using Cpaciente; // AJUSTA este using al namespace real de tus entidades/enums
using Cpaciente.Commands;
using Cpaciente.Data;
using Cpaciente.Sdk;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CPaciente.Handlers.Commands;

public sealed class FinalizeEncounterCommandHandler : IRequestHandler<FinalizeEncounterCommand>
{
    private readonly CpacienteDbContext _context;

    public FinalizeEncounterCommandHandler(CpacienteDbContext context)
    {
        _context = context;
    }

    public async Task Handle(FinalizeEncounterCommand request, CancellationToken cancellationToken)
    {
        var encounter = await _context.Encounters
            .FirstOrDefaultAsync(e => e.Id == request.EncounterId, cancellationToken);

        if (encounter is null)
        {
            throw new KeyNotFoundException($"No se encontro la consulta con id {request.EncounterId}.");
        }

        if (encounter.Status != EncounterStatus.InProgress)
        {
            throw new InvalidOperationException(
                $"Solo se puede finalizar una consulta en estado InProgress. Estado actual: {encounter.Status}.");
        }

        encounter.Status = EncounterStatus.Completed;
        encounter.EndedAt = DateTime.UtcNow;
        encounter.UpdatedAt = DateTime.UtcNow;

        if (!string.IsNullOrWhiteSpace(request.Data.Notes))
        {
            encounter.Notes = request.Data.Notes;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
