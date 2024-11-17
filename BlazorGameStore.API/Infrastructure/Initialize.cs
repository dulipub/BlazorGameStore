using BlazorGameStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorGameStore.API.Infrastructure;

public static class Initialize
{
    public static void Configure(IApplicationBuilder app)
    {
        var scoped = app.ApplicationServices.CreateScope();
        var context = scoped.ServiceProvider.GetRequiredService<GameStoreContext>();
        SeedData(context);
    }
    private static void SeedData(GameStoreContext context)
    {
        //seed data
        var genres = new List<Genre>() {
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
        context.Genres.AddRange(genres);
        context.SaveChanges();

        var games = new List<Game>() {
            new Game { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", GenreId = 1, Price = 59.99m, ReleaseDate = new DateOnly(2017, 3, 3) },
            new Game { Id = 2, Name = "Super Mario Odyssey", GenreId = 2, Price = 59.99m, ReleaseDate = new DateOnly(2017, 10, 27) },
            new Game { Id = 3, Name = "Minecraft", GenreId = 3, Price = 29.99m, ReleaseDate = new DateOnly(2011, 11, 18) },
            new Game { Id = 4, Name = "The Witcher 3: Wild Hunt", GenreId = 4, Price = 39.99m, ReleaseDate = new DateOnly(2015, 5, 19) },
            new Game { Id = 5, Name = "Dark Souls", GenreId = 5, Price = 39.99m, ReleaseDate = new DateOnly(2011, 6, 24) },
            new Game { Id = 6, Name = "DOOM Eternal", GenreId = 6, Price = 59.99m, ReleaseDate = new DateOnly(2020, 3, 20) },
            new Game { Id = 7, Name = "Civilization VI", GenreId = 7, Price = 59.99m, ReleaseDate = new DateOnly(2016, 10, 21) },
            new Game { Id = 8, Name = "Stellaris", GenreId = 7, Price = 39.99m, ReleaseDate = new DateOnly(2016, 5, 9) },
            new Game { Id = 9, Name = "Age of Empires II: Definitive Edition", GenreId = 7, Price = 29.99m, ReleaseDate = new DateOnly(2019, 11, 14) }
        };

        context.Games.AddRange(games);
        context.SaveChanges();
    }
}