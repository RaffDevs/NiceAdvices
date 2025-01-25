using MediatR;
using Microsoft.AspNetCore.Mvc;
using NiceAdvices.Shared.InputModels;
using NiceAdvives.Application.Commands.DeleteAdvice;
using NiceAdvives.Application.Commands.SaveAdvice;
using NiceAdvives.Application.Commands.TranslateAdvice;
using NiceAdvives.Application.Queries.GetAdvice;
using NiceAdvives.Application.Queries.GetFavoriteAdvices;

namespace NiceAdvices.Web.Controllers;

[ApiController]
[Route("advice")]
public class AdviceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdviceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAdviceQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetFavorites()
    {
        var query = new GetFavoriteAdvicesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveAdviceInputModel model)
    {
        var command = new SaveAdviceCommand { Model = model };
        await _mediator.Send(command);
        return Created();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAdviceCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("translate")]
    public async Task<IActionResult> Translate([FromBody] int id)
    {
        var command = new TranslateAdviceCommand { AdviceId = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}