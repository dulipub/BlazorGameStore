using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorGameStore.API.Models;

public class Game : ModelBase
{
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }

    [ForeignKey("GenreId")]
    public Genre? Genre { get; set; }
}