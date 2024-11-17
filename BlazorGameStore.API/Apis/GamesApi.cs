using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Requests.Game;
using BlazorGameStore.API.Responses;
using BlazorGameStore.API.Services;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Results = Microsoft.AspNetCore.Http.HttpResults.Results<Microsoft.AspNetCore.Http.HttpResults.Ok, Microsoft.AspNetCore.Http.HttpResults.BadRequest>;

namespace BlazorGameStore.API.Apis;

public static class GamesApi
{
    public static RouteGroupBuilder MapGamesApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/games");

        api.MapPost("/list", GamesList);
        api.MapGet("/{id}", GetGame);
        api.MapPost("/", CreateGame);
        api.MapPut("/update", UpdateGame);
        api.MapDelete("/{id}", DeleteGame);

        return api.WithOpenApi().AllowAnonymous();
    }

    [ProducesResponseType(typeof(GameResponse), StatusCodes.Status200OK)]
    private static async Task<Results<Ok<GameResponse>, BadRequest>> GetGame(
        int id,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var result = await service.GetGame(id, cancellation);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ListResponse<GameResponse>>, BadRequest>> GamesList(
        [FromBody] ListRequest request,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var response = await service.GetGamesList(request, cancellation);
        return TypedResults.Ok(response);
    }

    [ProducesResponseType(typeof(GameResponse), StatusCodes.Status200OK)]
    private static async Task<Results<Ok<GameResponse>, BadRequest>> CreateGame(
        [FromBody] CreateGameRequest request,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var result = await service.CreateGame(request, cancellation);
        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest>> DeleteGame(
        int id,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        await service.DeleteGame(id, cancellation);
        return TypedResults.Ok(true);
    }

    private static async Task<Results<Ok<GameResponse>, BadRequest>> UpdateGame(
        [FromBody] UpdateGameRequest request,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var result = await service.UpdateGame(request, cancellation);
        return TypedResults.Ok(result);
    }
}
