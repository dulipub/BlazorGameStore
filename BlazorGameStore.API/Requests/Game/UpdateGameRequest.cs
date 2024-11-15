using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.API.Requests.Game;

public class UpdateGameRequest
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string GenreId { get; set; }

    [Required]
    [Range(0, 1000)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
