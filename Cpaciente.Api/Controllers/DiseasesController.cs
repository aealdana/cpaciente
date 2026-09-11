using Cpaciente.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

[Route("api/diseases")]
[ApiController]
public class DiseasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiseasesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene el catalogo de enfermedades
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetDiseases()
    {
        var result = await _mediator.Send(new GetDiseasesQuery());
        return Ok(result);
    }
}
