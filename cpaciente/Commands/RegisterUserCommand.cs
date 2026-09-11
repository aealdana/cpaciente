using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Commands;

public sealed record RegisterUserCommand(UserRegistrationData Data) : IRequest<string>;
