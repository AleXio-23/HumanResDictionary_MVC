using System.Linq.Expressions;
using HumanResourceDictionary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.Data;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly DbContext Context;
    public IQueryable<TEntity> All { get; }

    public Repository(DbContext context)
    {
        Context = context;
        All = Context.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetAsync<TKey>(TKey id, CancellationToken cancellationToken) where TKey : struct
    {
        return (await Context.Set<TEntity>().FindAsync([id], cancellationToken))!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        Context.Set<TEntity>().AddRange(entities);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task RemoveAllAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var entities = Context.Set<TEntity>().Where(predicate).ToList();

        if (entities is { Count: > 0 })
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync(cancellationToken);
        }
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().AnyAsync(predicate);
    }
}