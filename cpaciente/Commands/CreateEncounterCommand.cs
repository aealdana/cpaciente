using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record CreateEncounterCommand(int PatientId, EncounterCreationData Data)
    : IRequest<EncounterCreationOutput>;
