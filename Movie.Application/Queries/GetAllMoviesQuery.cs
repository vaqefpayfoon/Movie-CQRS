using System;
using System.Collections.Generic;
using MediatR;

namespace Movie.Application;
public class GetAllMoviesQuery : IRequest<IEnumerable<MovieResponse>>
{
    public GetAllMoviesQuery()
    {

    }
}