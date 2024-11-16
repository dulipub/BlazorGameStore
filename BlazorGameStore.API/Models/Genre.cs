namespace BlazorGameStore.API.Models;

public class Genre : ModelBase
{
    public int GenreId { get; set; }
    public required string Name { get; set; }
}
