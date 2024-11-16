using BlazorGameStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorGameStore.API.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Name = "The Legend of Zelda: Breath of the Wild", GenreId = "Action-Adventure", Price = 59.99m, ReleaseDate = new DateOnly(2017, 3, 3) },
            new Game { Id = 2, Name = "Super Mario Odyssey", GenreId = "Platformer", Price = 59.99m, ReleaseDate = new DateOnly(2017, 10, 27) },
            new Game { Id = 3, Name = "Minecraft", GenreId = "Sandbox", Price = 29.99m, ReleaseDate = new DateOnly(2011, 11, 18) },
            new Game { Id = 4, Name = "The Witcher 3: Wild Hunt", GenreId = "RPG", Price = 39.99m, ReleaseDate = new DateOnly(2015, 5, 19) },
            new Game { Id = 5, Name = "Dark Souls", GenreId = "Action", Price = 39.99m, ReleaseDate = new DateOnly(2011, 6, 24) },
            new Game { Id = 6, Name = "DOOM Eternal", GenreId = "First-Person-Shooter", Price = 59.99m, ReleaseDate = new DateOnly(2020, 3, 20) },
            new Game { Id = 7, Name = "Civilization VI", GenreId = "Strategy", Price = 59.99m, ReleaseDate = new DateOnly(2016, 10, 21) },
            new Game { Id = 8, Name = "Stellaris", GenreId = "Strategy", Price = 39.99m, ReleaseDate = new DateOnly(2016, 5, 9) },
            new Game { Id = 9, Name = "Age of Empires II: Definitive Edition", GenreId = "Strategy", Price = 29.99m, ReleaseDate = new DateOnly(2019, 11, 14) }
        );
    }
}