using System;
using MediatR;

namespace Movie.Application;
public class GetMovieByIdQuery : IRequest<MovieResponse>
{
    public Guid Id { get; set; }

    public GetMovieByIdQuery(Guid id)
    {
        Id = id;
    }
}