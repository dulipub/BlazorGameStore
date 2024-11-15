using System.ComponentModel.DataAnnotations;

namespace BlazorGameStore.API.Requests;

public class ListRequest
{
    [Range(0, 100)]
    public int Take { get; set; } = 100;
    public int Start { get; set; } = 0;
}
