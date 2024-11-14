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

    [ProducesResponseType(typeof(GameResponse), StatusCodes.Status200OK)]
    private static async Task<Results<Ok<GameResponse>, BadRequest>> GetGame(
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
