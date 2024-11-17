using BlazorGameStore.API.Models;
using System.Linq.Expressions;

namespace BlazorGameStore.API.Repositories;

public interface IRepository<T> where T : ModelBase
{
    public Task<T> Get(int id, CancellationToken cancellation);
    public Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>> filter,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
        params Expression<Func<T, object>>[] includes
    );

    public Task<List<T>> List(int start, int take, CancellationToken cancellation);

    public Task<List<T>> ListDescending(int start, int take, CancellationToken cancellation);

    public Task Add(T entity, CancellationToken cancellation);

    public Task Remove(T entity, CancellationToken cancellation);

    public Task<int> TotalCount();

    public Task UpdateAll();
}