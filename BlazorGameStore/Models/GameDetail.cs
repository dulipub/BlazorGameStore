using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.Models;

public class GameDetail
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    public string? GenreId { get; set; }

    [Required]
    [Range(0,1000)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}