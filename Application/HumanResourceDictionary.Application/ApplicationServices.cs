using HumanResourceDictionary.Application.Services.Dictionaries.Gender;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourceDictionary.Application;

public static class ApplicationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGenderServices, GenderServices>();
        return services;
    }
}