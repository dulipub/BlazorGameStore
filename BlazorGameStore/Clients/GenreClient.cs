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
            new Genre { GenreId = 6, Name = "First-Person-Shooter" },
            new Genre { GenreId = 7, Name = "Strategy" },
            new Genre { GenreId = 8, Name = "Sports" },
            new Genre { GenreId = 9, Name = "Racing" },
            new Genre { GenreId = 10, Name = "Kids" }
        };
    }

    public List<Genre> GetData()
    {
        return Genres;
    }
}