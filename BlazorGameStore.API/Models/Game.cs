using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.API.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}