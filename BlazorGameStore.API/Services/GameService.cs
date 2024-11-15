using BlazorGameStore.API.Models;
using BlazorGameStore.API.Repositories;
using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Responses;
using Mapster;

namespace BlazorGameStore.API.Services;

public interface IGameService
{
    public Task<Game> GetGame(int id, CancellationToken cancellation);

    public Task<ListResponse<GameResponse>> GetGamesList(ListRequest request, CancellationToken cancellation);
}

public class GameService(IRepository<Game> repository) : IGameService
{
    public async Task<Game> GetGame(int id, CancellationToken cancellation)
    {
        var game = await repository.Get(id, cancellation);
        ArgumentNullException.ThrowIfNull(game);
        return game;
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
}
