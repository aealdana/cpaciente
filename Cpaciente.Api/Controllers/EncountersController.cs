using Cpaciente.Commands;
using Cpaciente.Queries;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

[Route("api/encounters")]
[ApiController]
[Authorize]
public class EncountersController : ControllerBase
{
    private readonly IMediator _mediator;

    public EncountersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Busca encounters, opcionalmente filtrados por estado (ej. ?status=Waiting)
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> GetEncounters([FromQuery] string? status)
    {
        try
        {
            var result = await _mediator.Send(new GetEncountersQuery(status));
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Inicia una consulta (Waiting -> InProgress)
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost("{encounterId}/start")]
    public async Task<IActionResult> StartEncounter([FromRoute] int encounterId)
    {
        try
        {
            await _mediator.Send(new StartEncounterCommand(encounterId));
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Finaliza una consulta (InProgress -> Completed)
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost("{encounterId}/finalize")]
    public async Task<IActionResult> FinalizeEncounter([FromRoute] int encounterId, [FromBody] EncounterFinalizationData data)
    {
        try
        {
            await _mediator.Send(new FinalizeEncounterCommand(encounterId, data));
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}
