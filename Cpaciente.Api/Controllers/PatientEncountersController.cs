using Cpaciente.Commands;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

// Reemplaza tu PatientEncountersController.cs existente por este archivo:
// mantiene el GET que ya tenias (sin Authorize, como estaba) y agrega el
// POST nuevo para crear un encounter (con Authorize).
[Route("api/patients")]
[ApiController]
public class PatientEncountersController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientEncountersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene el historial de consultas (encounters) de un paciente
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{patientId}/encounters")]
    public async Task<IActionResult> GetPatientEncounters([FromRoute] int patientId)
    {
        try
        {
            var result = await _mediator.Send(new GetPatientEncountersQuery(patientId));
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Crea un encounter nuevo para un paciente existente
    /// </summary>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost("{patientId}/encounters")]
    public async Task<IActionResult> CreateEncounter([FromRoute] int patientId, [FromBody] EncounterCreationData data)
    {
        try
        {
            var result = await _mediator.Send(new CreateEncounterCommand(patientId, data));
            return CreatedAtAction(nameof(GetPatientEncounters), new { patientId }, result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
