using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record FinalizeEncounterCommand(int EncounterId, EncounterFinalizationData Data) : IRequest;
