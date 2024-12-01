namespace BlazorGameStore.Models.Responses;

public class ListResponse<T>
{
    public List<T>? Results { get; set; }

    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
}
