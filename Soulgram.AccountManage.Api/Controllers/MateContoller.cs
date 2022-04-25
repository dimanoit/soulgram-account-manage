using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Commands;
using Soulgram.AccountManage.Application.Commands.Mate;
using Soulgram.AccountManage.Application.Models.Requests;
using Soulgram.AccountManage.Application.Models.Response;
using Soulgram.AccountManage.Application.Queries;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class MateController : ControllerBase
{
    private readonly IMediator _mediator;

    public MateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task UploadMateRequest([FromBody] MateRequestModel mateRequestModel)
    {
        var createMateRequestCommand = new SendMateRequestCommand(mateRequestModel);
        await _mediator.Send(createMateRequestCommand);
    }

    [HttpPatch("approve")]
    public async Task ApproveMadeRequest([FromBody] MateRequestModel editModel)
    {
        var approveMateRequestCommand = new ApproveMateRequestCommand(editModel);
        await _mediator.Send(approveMateRequestCommand);
    }
    
    [HttpPatch("reject")]
    public async Task RejectMadeRequest([FromBody] MateRequestModel editModel)
    {
        var rejectMateRequestCommand = new RejectMateRequestCommand(editModel);
        await _mediator.Send(rejectMateRequestCommand);
    }
    
    [HttpGet("requests/{userId}")]

    public async Task<IEnumerable<MateRequestResponse>?> GetMateRequests(string userId)
    {
        var getMateRequestsQuery = new GetMateRequestsQuery(userId);
        return await _mediator.Send(getMateRequestsQuery);
    }
    
    [HttpGet("{userId}")]

    public async Task<IEnumerable<CompactUserInfoResponse>?> GetUserMates(string userId)
    {
        var getMateRequestsQuery = new GetUserMatesQuery(userId);
        return await _mediator.Send(getMateRequestsQuery);
    }
}