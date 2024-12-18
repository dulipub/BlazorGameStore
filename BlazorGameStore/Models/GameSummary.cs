﻿namespace BlazorGameStore.Models;

public class GameSummary
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Genre { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}