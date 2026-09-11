using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Queries;

public sealed record GetDiseasesQuery() : IRequest<List<DiseaseOutput>>;
