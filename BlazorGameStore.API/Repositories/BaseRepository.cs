using BlazorGameStore.API.Models;
using BlazorGameStore.API.Requests;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BlazorGameStore.API.Repositories;


public class BaseRepository<T>(GameStoreContext context) : IRepository<T> where T : ModelBase
{
    public virtual async Task<T> Get(int id, CancellationToken cancellation)
    {
        var entity = await context.FindAsync<T>(id, cancellation);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>> filter, 
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, 
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = context.Set<T>();
        foreach (Expression<Func<T, object>> include in includes)
        {
            query = query.Include(include);
        }

        query = query.Where(filter);
        query = orderBy(query);

        return await query.ToListAsync().ConfigureAwait(false);
    }


    public virtual async Task<List<T>> List(int start, int take, CancellationToken cancellation)
    {
        return await context.Set<T>().OrderBy(e => e.Id).Skip(start).Take(take).ToListAsync(cancellation);
    }

    public virtual async Task<List<T>> ListDescending(int start, int take, CancellationToken cancellation)
    {
        return await context.Set<T>().OrderByDescending(e => e.Id).Skip(start).Take(take).ToListAsync(cancellation);
    }

    public virtual async Task Add(T entity, CancellationToken cancellation)
    {
        entity.IsActive = true;
        entity.CreatedDate = DateTime.UtcNow;

        await context.Set<T>().AddAsync(entity, cancellation);
        await context.SaveChangesAsync(cancellation);
    }

    //for simplicity we do not soft delete
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
