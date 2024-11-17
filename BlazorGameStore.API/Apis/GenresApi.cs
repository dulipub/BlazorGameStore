using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Responses;
using BlazorGameStore.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorGameStore.API.Apis;

public static class GenresApi
{
    public static RouteGroupBuilder MapGenresApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/api/genre");

        api.MapPost("/list", GenreList);
        api.MapGet("/{id}", GetGenre);
        //api.MapPost("/", CreateGame);
        //api.MapPut("/update", UpdateGame);
        //api.MapDelete("/{id}", DeleteGame);

        return api.WithOpenApi().AllowAnonymous();
    }

    private static async Task<Results<Ok<GenreResponse>, BadRequest>> GetGenre(
        int id,
        [FromServices] IGenreService service,
        CancellationToken cancellation
        )
    {
        var result = await service.GetGenre(id, cancellation);
        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ListResponse<GenreResponse>>, BadRequest>> GenreList(
        [FromBody] ListRequest request,
        [FromServices] IGenreService service,
        CancellationToken cancellation
        )
    {
        var result = await service.GetAllGenres(request, cancellation);
        return TypedResults.Ok(result);
    }
}
