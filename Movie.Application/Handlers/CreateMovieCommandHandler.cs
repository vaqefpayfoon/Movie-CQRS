using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Movie.Core;
using Movie.Infrastructure;

namespace Movie.Application;
public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieResponse>
{
    private readonly IRepository<MovieEntity> _repo;
    public CreateMovieCommandHandler(IRepository<MovieEntity> repo)
    {
        _repo = repo;
    }
    public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movieEntity = EntityMapper.Mapper.Map<MovieEntity>(request);
        if (movieEntity is null)
        {
            throw new ApplicationException("There is an issue with mapping...");
        }

        var newMovie = await _repo.AddAsync(movieEntity);
        var movieResponse = EntityMapper.Mapper.Map<MovieResponse>(newMovie);
        return movieResponse;
    }
}