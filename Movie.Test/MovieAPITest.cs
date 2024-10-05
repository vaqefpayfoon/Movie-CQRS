using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Movie.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Movie.Core;

namespace Movie.Test;

public class MovieAPITest : IClassFixture<WebApplicationFactory<Program>>
{


    public MovieAPITest()
    {

    }

    [Fact]
    public async Task Get_MovieById()
    {
        var client = new HttpClient();
        // Act
        string id = "0e479ddf-fa5a-47b3-bcfb-d418f222eaa6";
        var response = await client.GetFromJsonAsync<MovieEntity>("http://localhost:8080/api/v1/Movie/0e479ddf-fa5a-47b3-bcfb-d418f222eaa6");
        Assert.IsType<MovieEntity>(response);
        // Assert
    }

    [Fact]
    public async Task Get_ReturnsWeatherForecast()
    {
        var client = new HttpClient();
        // Act
        string id = "0e479ddf-fa5a-47b3-bcfb-d418f222eaa6";
        var response = await client.GetAsync("http://localhost:8080/api/v1/Movie/0e479ddf-fa5a-47b3-bcfb-d418f222eaa6");

        // Assert
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Contains("Die Another Day", responseString);
    }
}