using MediatR;

namespace Cpaciente.Commands;

public sealed record StartEncounterCommand(int EncounterId) : IRequest;
