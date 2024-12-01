using BlazorGameStore.Models;
using BlazorGameStore.Models.Responses;

namespace BlazorGameStore.Clients;

public class GenreClient(HttpClient httpClient)
{
    public async Task<List<Genre>> GetDataAsync()
    {
        var req = new
        {
            take = 100,
            start = 0
        };
        var response = await httpClient.PostAsJsonAsync("genre/list", req);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<ListResponse<Genre>>();
            return content?.Results ?? [];
        }

        return [];
    }
}