using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Movie.Core;
using Movie.Infrastructure;

namespace Movie.Application;
public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    private readonly IRepository<MovieEntity> _repo;

    public GetMovieByIdHandler(IRepository<MovieEntity> repo)
    {
        _repo = repo;
    }
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        var movie = await _repo.GetByIdAsync(request.Id);
        var movieResponse = EntityMapper.Mapper.Map<MovieResponse>(movie);
        return movieResponse;
    }

}