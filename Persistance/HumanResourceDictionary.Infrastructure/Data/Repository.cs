using System.Linq.Expressions;
using HumanResourceDictionary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;

    Repository(DbContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> All { get; }

    public virtual async Task<TEntity> GetAsync<TKey>(TKey id, CancellationToken cancellationToken) where TKey : struct
    {
        return (await _context.Set<TEntity>().FindAsync([id], cancellationToken))!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        _context.Set<TEntity>().AddRange(entities);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task RemoveAllAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var entities = _context.Set<TEntity>().Where(predicate).ToList();

        if (entities is { Count: > 0 })
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().AnyAsync(predicate);
    }
}