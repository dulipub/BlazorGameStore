
using BlazorGameStore.API.Models;
using BlazorGameStore.API.Responses;
using BlazorGameStore.API.Services;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorGameStore.API.Apis;

public static class GamesApi
{
    public static RouteGroupBuilder MapGameApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/games");

        api.MapGet("/", GetAllGames);
        api.MapGet("/{id}", GetGame);
        //api.MapPost("/", CreateTodo);
        //api.MapPut("/{id}", UpdateTodo);
        //api.MapDelete("/{id}", DeleteTodo);

        return api.WithOpenApi();
    }

    private static async Task<Ok<GameResponse>> GetGame(
        int id,
        [FromServices] IGameService service
        )
    {
        var result = await service.GetGame(id);
        var response = result.Adapt<GameResponse>();

        return TypedResults.Ok(response);
    }

    private static async Task<ListResponse<GameResponse>> GetAllGames(HttpContext context)
    {
        throw new NotImplementedException();
    }
}
