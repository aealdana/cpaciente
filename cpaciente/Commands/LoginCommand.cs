using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record LoginCommand(LoginData Data) : IRequest<AuthenticationOutput>;
