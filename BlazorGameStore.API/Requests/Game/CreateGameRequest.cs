﻿using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.API.Requests.Game;

public class CreateGameRequest
{
    public required string Name { get; set; }
    public required string GenreId { get; set; }

    [Required]
    [Range(0, 1000)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
