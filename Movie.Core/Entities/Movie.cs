using System.ComponentModel.DataAnnotations;

namespace Movie.Core;

public class MovieEntity : BaseEntity
{
    [Required]
    public string MovieName { get; set; }
    public string DirectorName { get; set; }
    public string ReleaseYear { get; set; }
}