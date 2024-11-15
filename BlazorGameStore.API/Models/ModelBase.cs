namespace BlazorGameStore.API.Models;

public class ModelBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; } //soft delete
    public DateTime CreatedDate { get; set; }
}
