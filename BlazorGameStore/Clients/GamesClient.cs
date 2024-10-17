using BlazorGameStore.Models;

namespace BlazorGameStore.Clients;

public class GamesClient
{
    private List<GameSummary> Games {  get; set; }

    public GamesClient()
    {
        Games = new List<GameSummary>
        {
            new GameSummary { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", Genre = "Action-Adventure", Price = 59.99m, ReleaseDate = new DateOnly(2017, 3, 3) },
            new GameSummary { Id = 2, Name = "Super Mario Odyssey", Genre = "Platformer", Price = 59.99m, ReleaseDate = new DateOnly(2017, 10, 27) },
            new GameSummary { Id = 3, Name = "Minecraft", Genre = "Sandbox", Price = 29.99m, ReleaseDate = new DateOnly(2011, 11, 18) },
            new GameSummary { Id = 4, Name = "The Witcher 3: Wild Hunt", Genre = "RPG", Price = 39.99m, ReleaseDate = new DateOnly(2015, 5, 19) },
            new GameSummary { Id = 5, Name = "Dark Souls", Genre = "Action", Price = 39.99m, ReleaseDate = new DateOnly(2011, 6, 24) },
            new GameSummary { Id = 6, Name = "DOOM Eternal", Genre = "First-Person-Shooter", Price = 59.99m, ReleaseDate = new DateOnly(2020, 3, 20) },
            new GameSummary { Id = 7, Name = "Civilization VI", Genre = "Strategy", Price = 59.99m, ReleaseDate = new DateOnly(2016, 10, 21) },
            new GameSummary { Id = 8, Name = "Stellaris", Genre = "Strategy", Price = 39.99m, ReleaseDate = new DateOnly(2016, 5, 9) },
            new GameSummary { Id = 9, Name = "Age of Empires II: Definitive Edition", Genre = "Strategy", Price = 29.99m, ReleaseDate = new DateOnly(2019, 11, 14) }
        };
    }
    public List<GameSummary> GetData()
    {
        return Games;
    }
}
