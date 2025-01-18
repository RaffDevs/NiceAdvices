using MediatR;
using Microsoft.AspNetCore.Mvc;
using NiceAdvices.Shared.InputModels;
using NiceAdvives.Application.Commands.SaveAdvice;
using NiceAdvives.Application.Queries.GetAdvice;

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

    [HttpPost]
    public async Task<IActionResult> Create(SaveAdviceInputModel model)
    {
        var command = new SaveAdviceCommand { Model = model };
        await _mediator.Send(command);
        return Created();
    }
}