using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Queries;

public sealed record GetPatientEncountersQuery(int PatientId) : IRequest<List<EncounterHistoryOutput>>;
