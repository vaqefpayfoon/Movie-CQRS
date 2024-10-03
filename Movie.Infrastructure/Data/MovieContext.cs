using Microsoft.EntityFrameworkCore;
using Movie.Core;

namespace Movie.Infrastructure;
public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options):base(options)
    {
        
    }

    public DbSet<MovieEntity> Movies { get; set; }
}