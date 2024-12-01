using BlazorGameStore.Models;
using BlazorGameStore.Models.Responses;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Collections.Generic;

namespace BlazorGameStore.Clients;

public class GamesClient(HttpClient httpClient)
{
    private List<GameSummary> Games {  get; set; }

    private readonly List<Genre> Genres;

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

    public void Add(GameDetail gameDetail)
    {
        var newGame = new GameSummary
        {
            Id = Games.Count + 1,
            Name = gameDetail.Name,
            Genre = GetGenreById(gameDetail.GenreId),
            Price = gameDetail.Price,
            ReleaseDate = gameDetail.ReleaseDate
        };

        Games.Add(newGame);
    }

    public GameDetail GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = Genres.Single(g => g.Name.Equals(game.Genre, StringComparison.CurrentCultureIgnoreCase));
        var gameDetail = new GameDetail
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.GenreId.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        return gameDetail;
    }

    public void UpdateGame(GameDetail gameDetail)
    {
        var genre = GetGenreById(gameDetail?.GenreId);
        var game = GetGameSummaryById(gameDetail.Id);

        game.Name = gameDetail.Name;
        game.Price = gameDetail.Price;
        game.ReleaseDate = gameDetail.ReleaseDate;
        game.Genre = genre;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        Games.Remove(game);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        var game = Games.Find(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private string GetGenreById(string id)
    {
        ArgumentNullException.ThrowIfNull(id, "id");
        return Genres.FirstOrDefault(g => g.GenreId.ToString() == id)?.Name ?? string.Empty;
    }
}
