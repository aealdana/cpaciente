using Cpaciente.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cpaciente.Api.Controllers;

[Route("api/allergies")]
[ApiController]
public class AllergiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AllergiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Obtiene el catalogo de alergias
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllergies()
    {
        var result = await _mediator.Send(new GetAllergiesQuery());
        return Ok(result);
    }
}
