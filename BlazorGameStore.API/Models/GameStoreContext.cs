using Microsoft.EntityFrameworkCore;

namespace BlazorGameStore.API.Models;

public class GameStoreContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {
    }
}