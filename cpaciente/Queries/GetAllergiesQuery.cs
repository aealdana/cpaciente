using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Queries;

public sealed record GetAllergiesQuery() : IRequest<List<AllergyOutput>>;
