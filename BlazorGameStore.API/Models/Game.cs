using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.API.Models;

public class Game : ModelBase
{
    public required string Name { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}