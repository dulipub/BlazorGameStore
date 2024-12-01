using BlazorGameStore.Models;
using BlazorGameStore.Models.Responses;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Collections.Generic;

namespace BlazorGameStore.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<List<GameSummary>> GetDataAsync()
    {
        var req = new
        {
            take = 100,
            start = 0
        };
        var response = await httpClient.PostAsJsonAsync("games/list", req);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadFromJsonAsync<ListResponse<GameSummary>>();
            return content?.Results ?? [];
        }

        return [];
    }

    public async Task AddAsync(GameDetail gameDetail)
    {
        await httpClient.PostAsJsonAsync("games/", gameDetail);
    }

    public async Task<GameDetail> GetGameAsync(int id)
    {
        var response = await httpClient.GetFromJsonAsync<GameSummary>($"games/{id}");
        if (response is null)
        {
            throw new Exception("Could not find the game requested");
        }

        GameDetail result = new()
        {
            Id = response.Id,
            Name = response.Name,
            GenreId = response.GenreId.ToString(),
            Price = response.Price,
            ReleaseDate = response.ReleaseDate
        };

        return result;
    }

    public async Task UpdateGameAsync(GameDetail gameDetail)
    {
        await httpClient.PutAsJsonAsync("games/update", gameDetail);
    }

    public async Task DeleteGameAsync(int id)
    {
        await httpClient.DeleteAsync($"games/{id}");
    }
}
