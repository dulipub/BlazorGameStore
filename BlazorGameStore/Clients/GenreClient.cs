using BlazorGameStore.Models;

namespace BlazorGameStore.Clients;

public class GenreClient(HttpClient httpClient)
{
    private List<Genre> Genres { get; set; }

    public List<Genre> GetData()
    {
        return Genres;
    }
}