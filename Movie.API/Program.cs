
namespace Movie.Application;

using Microsoft.EntityFrameworkCore;
using Movie.Infrastructure;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddApiVersioning();
        builder.Services.AddDbContext<MovieContext>(
            m => m.UseSqlite(builder.Configuration.GetConnectionString("MovieConnection")), ServiceLifetime.Singleton);

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddApplication();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        var app = builder.Build();

        // // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

        app.MapControllers();

        // using (var scope = app.Services.CreateScope())
        // {
        //     var services = scope.ServiceProvider;
        //     var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        //     try
        //     {
        //         var moviesContext = services.GetRequiredService<MovieContext>();
        //         await MovieContextSeed.SeedAsync(moviesContext, loggerFactory);
        //     }
        //     catch (Exception ex)
        //     {
        //         var logger = loggerFactory.CreateLogger<Program>();
        //         logger.LogError($"Exception occured in API: {ex.Message}");
        //     }
        // }

        app.Run();

    }
}


