using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Model.Requests;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class HobbyController : ControllerBase
{
    private readonly IMediator _mediator;

    public HobbyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task CreateHobby([FromBody] CreateHobbyRequest request)
    {
        var command = new CreateHobbyCommand()
        {
            RequestModel = request
        };

        await _mediator.Send(command);
    }
}