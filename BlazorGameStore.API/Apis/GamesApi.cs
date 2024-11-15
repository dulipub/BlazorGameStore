using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Responses;
using BlazorGameStore.API.Services;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Results = Microsoft.AspNetCore.Http.HttpResults.Results<Microsoft.AspNetCore.Http.HttpResults.Ok, Microsoft.AspNetCore.Http.HttpResults.BadRequest>;

namespace BlazorGameStore.API.Apis;

public static class GamesApi
{
    public static RouteGroupBuilder MapGameApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/games");

        api.MapGet("/", GamesList);
        api.MapGet("/{id}", GetGame);
        //api.MapPost("/", CreateTodo);
        //api.MapPut("/{id}", UpdateTodo);
        //api.MapDelete("/{id}", DeleteTodo);

        return api.WithOpenApi();
    }

    [ProducesResponseType(typeof(GameResponse), StatusCodes.Status200OK)]
    private static async Task<Results<Ok<GameResponse>, BadRequest>> GetGame(
        int id,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var result = await service.GetGame(id, cancellation);
        var response = result.Adapt<GameResponse>();

        return TypedResults.Ok(response);
    }

    private static async Task<Results<Ok<ListResponse<GameResponse>>, BadRequest>> GamesList(
        ListRequest request,
        [FromServices] IGameService service,
        CancellationToken cancellation
        )
    {
        var response = await service.GetGamesList(request, cancellation);
        return TypedResults.Ok(response);
    }
}
