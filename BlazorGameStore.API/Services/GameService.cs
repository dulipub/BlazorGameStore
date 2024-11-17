using BlazorGameStore.API.Models;
using BlazorGameStore.API.Repositories;
using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Requests.Game;
using BlazorGameStore.API.Responses;
using Mapster;

namespace BlazorGameStore.API.Services;

public interface IGameService
{
    public Task<GameResponse> GetGame(int id, CancellationToken cancellation);

    public Task<ListResponse<GameResponse>> GetGamesList(ListRequest request, CancellationToken cancellation);

    public Task<GameResponse> CreateGame(CreateGameRequest request, CancellationToken cancellation);

    public Task DeleteGame(int id, CancellationToken cancellation);

    public Task<GameResponse> UpdateGame(UpdateGameRequest request, CancellationToken cancellation);
}

public class GameService(IRepository<Game> repository) : IGameService
{
    public async Task<GameResponse> GetGame(int id, CancellationToken cancellation)
    {
        var games = await repository.Get(
                g => g.Id == id,
                x => x.OrderBy(x => x.Id),
                g => g.Genre
            );
        var game = games.FirstOrDefault();
        ArgumentNullException.ThrowIfNull(game);
        return game.Adapt<GameResponse>();
    }

    public async Task<ListResponse<GameResponse>> GetGamesList(ListRequest request, CancellationToken cancellation)
    {
        var games = await repository.List(request.Start, request.Take, cancellation);
        var response = new ListResponse<GameResponse>()
        {
            Results = games.Adapt<List<GameResponse>>(),
            TotalCount = await repository.TotalCount(),
            PageSize = games.Count,
            PageNumber = request.Start / request.Take
        };

        return response;
    }

    public async Task<GameResponse> CreateGame(CreateGameRequest request, CancellationToken cancellation)
    {
        var game = request.Adapt<Game>();
        ArgumentNullException.ThrowIfNull(game);

        await repository.Add(game, cancellation);
        return game.Adapt<GameResponse>();
    }

    public async Task DeleteGame(int id, CancellationToken cancellation)
    {
        var game = await repository.Get(id, cancellation);
        ArgumentNullException.ThrowIfNull(game);

        await repository.Remove(game, cancellation);
    }

    public async Task<GameResponse> UpdateGame(UpdateGameRequest request, CancellationToken cancellation)
    {
        var game = await repository.Get(request.Id, cancellation);
        ArgumentNullException.ThrowIfNull(game);

        game.Name = request.Name;
        int.TryParse(request.GenreId, out var genre);
        game.GenreId = genre;
        game.Price = request.Price;
        game.ReleaseDate = request.ReleaseDate;

        await repository.UpdateAll();
        return game.Adapt<GameResponse>();
    }
}
