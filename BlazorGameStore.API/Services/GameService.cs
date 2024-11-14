using BlazorGameStore.API.Models;
using BlazorGameStore.API.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlazorGameStore.API.Services;

public interface IGameService
{
    public Task<Game> GetGame(int id);

    public Task<List<Game>> GetGamesList();
}

public class GameService(GameStoreContext context) : IGameService
{
    public async Task<Game> GetGame(int id)
    {
        var game = await context.Games.FindAsync(id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    public async Task<List<Game>> GetGamesList()
    {
        return await context.Games.ToListAsync();
    }
}
