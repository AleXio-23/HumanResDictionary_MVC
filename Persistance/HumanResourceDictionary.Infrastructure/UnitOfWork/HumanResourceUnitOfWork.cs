using HumanResourceDictionary.Infrastructure.Data;
using HumanResourceDictionary.Infrastructure.Entities;
using HumanResourceDictionary.Infrastructure.Generic;
using HumanResourceDictionary.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceDictionary.Infrastructure.UnitOfWork;

public class HumanResourceUnitOfWork : IHumanResourceUnitOfWork, IAsyncDisposable
{
    private readonly HumanResourceDbContext _context;

    public HumanResourceUnitOfWork(HumanResourceDbContext context)
    {
        _context = context;
        Genders = new GenericContextRepository<Gender>(_context);
        LocalizedGenderNames = new GenericContextRepository<LocalizedGenderNames>(_context);
        Cities = new GenericContextRepository<City>(_context);
        LocalizedCityNames = new GenericContextRepository<LocalizedCityName>(_context);
        Users = new GenericContextRepository<User>(_context);
        PhoneNumbersDictionary = new GenericContextRepository<PhoneNumberDictionary>(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    public IRepository<Gender> Genders { get; private set; }
    public IRepository<LocalizedGenderNames> LocalizedGenderNames { get; private set; }
    public IRepository<City> Cities { get; private set; }
    public IRepository<LocalizedCityName> LocalizedCityNames { get; private set; }
    public IRepository<User> Users { get; }
    public IRepository<PhoneNumberDictionary> PhoneNumbersDictionary { get; }
}