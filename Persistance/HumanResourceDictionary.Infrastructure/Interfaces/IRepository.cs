using System.Linq.Expressions;

namespace HumanResourceDictionary.Infrastructure.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> All { get; }
    Task<TEntity> GetAsync<TKey>(TKey id, CancellationToken cancellationToken) where TKey : struct;
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task RemoveAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
}