using Cpaciente.Commands;
using Cpaciente.Sdk;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

[Route("api/patients")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Registra un paciente nuevo
    /// </summary>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientCreationData data)
    {
        try
        {
            var patientId = await _mediator.Send(new CreatePatientCommand(data));
            return CreatedAtAction(nameof(CreatePatient), new { id = patientId }, new { id = patientId });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}
