using BlazorGameStore.Models;

namespace BlazorGameStore.Clients;

public class GenreClient
{
    private List<Genre> Genres { get; set; }
    public GenreClient()
    {
        Genres = new List<Genre>()
        {
            new Genre { GenreId = 1, Name = "Action-Adventure" },
            new Genre { GenreId = 2, Name = "Platformer" },
            new Genre { GenreId = 3, Name = "Sandbox" },
            new Genre { GenreId = 4, Name = "RPG" },
            new Genre { GenreId = 5, Name = "Action" },
            new Genre { GenreId = 5, Name = "First-Person-Shooter" },
            new Genre { GenreId = 5, Name = "Strategy" },
            new Genre { GenreId = 5, Name = "Sports" },
            new Genre { GenreId = 5, Name = "Racing" },
            new Genre { GenreId = 5, Name = "Kids" }
        };
    }

    public List<Genre> GetData()
    {
        return Genres;
    }
}