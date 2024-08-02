using HumanResourceDictionary.Infrastructure.Entities;

namespace HumanResourceDictionary.Infrastructure.Interfaces;

public interface IHumanResourceUnitOfWork : IDisposable
{
     IRepository<Gender> Genders { get; }
     IRepository<LocalizedGenderNames> LocalizedGenderNames { get; }
     IRepository<City> Cities { get; }
     IRepository<LocalizedCityName> LocalizedCityNames { get; }
     IRepository<User> Users { get; }
     IRepository<PhoneNumberDictionary> PhoneNumbersDictionary { get; }
}