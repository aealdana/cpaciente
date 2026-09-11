using Cpaciente.Sdk;
using MediatR;

namespace Cpaciente.Queries;

// Status es opcional: null trae todos los encounters, con valor filtra
// por ese estado exacto (ej. "Waiting").
public sealed record GetEncountersQuery(string? Status) : IRequest<List<EncounterSummaryOutput>>;
