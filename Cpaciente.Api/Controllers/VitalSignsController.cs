using Cpaciente.Commands;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

[Route("api/vital-signs")]
[ApiController]
[Authorize]
public class VitalSignsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VitalSignsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Actualiza (parcialmente) los signos vitales de un encounter
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPatch("{vitalSignId}")]
    public async Task<IActionResult> UpdateVitalSigns([FromRoute] int vitalSignId, [FromBody] VitalSignsUpdateData data)
    {
        try
        {
            await _mediator.Send(new UpdateVitalSignsCommand(vitalSignId, data));
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
