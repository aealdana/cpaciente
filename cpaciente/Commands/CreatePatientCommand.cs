using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record CreatePatientCommand(PatientCreationData Data) : IRequest<int>;
