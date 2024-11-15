using BlazorGameStore.API.Models;
using BlazorGameStore.API.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorGameStore.API.Repositories;


public class BaseRepository<T>(GameStoreContext context) : IRepository<T> where T : ModelBase
{
    public virtual async Task<T> Get(int id, CancellationToken cancellation)
    {
        var entity = await context.FindAsync<T>(id, cancellation);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }

    public virtual async Task<List<T>> List(int start, int take, CancellationToken cancellation)
    {
        return await context.Set<T>().Order().Skip(start).Take(take).ToListAsync(cancellation);
    }

    public virtual async Task<List<T>> ListDescending(int start, int take, CancellationToken cancellation)
    {
        return await context.Set<T>().OrderDescending().Skip(start).Take(take).ToListAsync(cancellation);
    }

    public virtual async Task Add(T entity, CancellationToken cancellation)
    {
        await context.Set<T>().AddAsync(entity, cancellation);
        await context.SaveChangesAsync(cancellation);
    }

    public virtual async Task Remove(T entity, CancellationToken cancellation)
    {
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync(cancellation);
    }

    public virtual async Task<int> TotalCount()
    {
        return await context.Set<T>().CountAsync();
    }

    public virtual async Task UpdateAll()
    {
        await context.SaveChangesAsync();
    }
}
