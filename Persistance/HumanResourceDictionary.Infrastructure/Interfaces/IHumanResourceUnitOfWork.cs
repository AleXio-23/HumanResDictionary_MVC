namespace HumanResourceDictionary.Infrastructure.Interfaces;

public interface IHumanResourceUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> CompleteAsync();
}