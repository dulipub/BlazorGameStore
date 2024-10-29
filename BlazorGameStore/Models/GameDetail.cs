using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.Models;

public class GameDetail
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? GenreId { get; set; }
    [Range(0,1000)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}