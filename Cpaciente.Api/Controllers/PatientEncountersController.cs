using Cpaciente.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

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
            var query = new GetPatientEncountersQuery(patientId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
