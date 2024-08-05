using HumanResourceDictionary.Application.Services.Dictionaries.City;
using HumanResourceDictionary.Application.Services.Dictionaries.Gender;
using HumanResourceDictionary.Application.Services.Users.AddUser;
using HumanResourceDictionary.Application.Services.Users.GetUsers;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourceDictionary.Application;

public static class ApplicationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGenderServices, GenderServices>();
        services.AddScoped<ICityServices, CityServices>();
        services.AddScoped<IAddUserService, AddUserService>();
        services.AddScoped<IGetUsersService, GetUsersService>();
        return services;
    }
}