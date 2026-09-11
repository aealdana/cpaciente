using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record UpdateVitalSignsCommand(int VitalSignId, VitalSignsUpdateData Data) : IRequest;
