using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Movie.Core;

namespace Movie.Infrastructure;


public class MovieContextSeed
{
    public static async Task SeedAsync(MovieContext movieContext, ILoggerFactory loggerFactory, int? retry = 0)
    {
        int retryForAvailability = retry is not null ? retry.Value : 0;
        try
        {
            //make sure database is there
            // await movieContext.Database.EnsureCreatedAsync();

            if (!movieContext.Movies.Any())
            {
                movieContext.Movies.AddRange(GetMovies());
                await movieContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability < 3)
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<MovieContextSeed>();
                log.LogError($"Exception occured while connecting: {ex.Message}");
                await SeedAsync(movieContext, loggerFactory, retryForAvailability);
            }
        }
    }

    private static IEnumerable<MovieEntity> GetMovies()
    {
        return new List<MovieEntity>()
        {
            new MovieEntity {Id= Guid.NewGuid(), CreateDateTime = DateTime.Now, MovieName = "Avatar", DirectorName = "James Cameron", ReleaseYear = "2009"},
            new MovieEntity {Id= Guid.NewGuid(), CreateDateTime = DateTime.Now, MovieName = "Titanic", DirectorName = "James Cameron", ReleaseYear = "1997"},
            new MovieEntity {Id= Guid.NewGuid(), CreateDateTime = DateTime.Now, MovieName = "Die Another Day", DirectorName = "Lee Tamahori", ReleaseYear = "2002"},
            new MovieEntity
            {
                Id= Guid.NewGuid(), CreateDateTime = DateTime.Now,
                MovieName = "Godzilla",
                DirectorName = "Gareth Edwards",
                ReleaseYear = "2014"
            }
        };
    }

}
