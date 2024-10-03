using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Movie.Core;
using Movie.Infrastructure;

namespace Movie.Application;
public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieResponse>>
{
    private readonly IRepository<MovieEntity> _repo;

    public GetAllMoviesHandler(IRepository<MovieEntity> repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<MovieResponse>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var movie = await _repo.GetAllAsync();
        var moviesResponse = EntityMapper.Mapper.Map<IEnumerable<MovieResponse>>(movie);
        return moviesResponse;
    }

}