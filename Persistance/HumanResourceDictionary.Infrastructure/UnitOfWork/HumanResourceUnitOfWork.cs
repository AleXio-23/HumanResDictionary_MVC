using HumanResourceDictionary.Infrastructure.Data;
using HumanResourceDictionary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork;

public class HumanResourceUnitOfWork(HumanResourceDbContext context) : IHumanResourceUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = new();

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repositoryType = typeof(Repository<>);
        var repositoryInstance =
            (IRepository<T>)Activator.CreateInstance(repositoryType!.MakeGenericType(typeof(T)), context)!;
        _repositories.Add(typeof(T), repositoryInstance!);
        return repositoryInstance!;
    }

    public async Task<int> CompleteAsync()
    {
        return await context.SaveChangesAsync();
    }

    void IDisposable.Dispose() => context.Dispose();
}