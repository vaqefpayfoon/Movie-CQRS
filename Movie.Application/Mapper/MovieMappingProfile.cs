using AutoMapper;
using Movie.Core;

namespace Movie.Application;
public class MovieMappingProfile: Profile
{
    public MovieMappingProfile()
    {
        CreateMap<MovieEntity, MovieResponse>().ReverseMap();
        CreateMap<MovieEntity, CreateMovieCommand>().ReverseMap();
    }
}