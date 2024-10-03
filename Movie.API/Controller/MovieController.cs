using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application;

public class MovieController : ApiController
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<MovieResponse>> GetMoviesById(Guid id)
    {
        var query = new GetMovieByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<MovieResponse>> CreateMovie([FromBody] CreateMovieCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<MovieResponse>>> GetAllMovies()
    {
        var query = new GetAllMoviesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}