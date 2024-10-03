using System;

namespace Movie.Application;
public class MovieResponse
{
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string MovieName { get; set; }
    public string DirectorName { get; set; }
    public string ReleaseYear { get; set; }
}