using BlazorGameStore.API.Models;
using BlazorGameStore.API.Repositories;
using BlazorGameStore.API.Requests;
using BlazorGameStore.API.Responses;
using Mapster;

namespace BlazorGameStore.API.Services;

public interface IGenreService
{
}


public class GenreService(IRepository<Genre> repository) : IGenreService
{
    public async Task<Genre> GetGenre(int id, CancellationToken cancellation)
    {
        var genre = await repository.Get(id, cancellation);
        ArgumentNullException.ThrowIfNull(genre);
        return genre;
    }

    public async Task<ListResponse<GenreResponse>> GetAllGenres(ListRequest request, CancellationToken cancellation)
    {
        var totalCount = await repository.TotalCount();
        var genres = await repository.List(0, totalCount, cancellation);
        var response = new ListResponse<GenreResponse>()
        {
            Results = genres.Adapt<List<GenreResponse>>(),
            TotalCount = await repository.TotalCount(),
            PageSize = totalCount,
            PageNumber = 1
        };

        return response;
    }
}
