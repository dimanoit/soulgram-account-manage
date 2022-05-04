using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soulgram.AccountManage.Application.Queries;

namespace Soulgram.AccountManage.Api.Controllers;

[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ICollection<string>?> GetAllGenres(CancellationToken cancellationToken)
    {
        var genresQuery = new GetGenresQuery();

        return await _mediator.Send(genresQuery, cancellationToken);
    }
}