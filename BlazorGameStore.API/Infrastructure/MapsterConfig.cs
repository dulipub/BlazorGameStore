using BlazorGameStore.API.Models;
using BlazorGameStore.API.Responses;
using Mapster;

namespace BlazorGameStore.API.Infrastructure;

public static class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Game, GameResponse>.NewConfig()
            .Map(dest => dest.Genre, src => src.Genre != null ? src.Genre.Name : "");
    }
}
