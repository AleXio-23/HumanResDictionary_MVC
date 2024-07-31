using HumanResourceDictionary.Infrastructure.Interfaces;
using HumanResourceDictionary.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResourceDictionary.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IHumanResourceUnitOfWork, HumanResourceUnitOfWork>();

        return services;
    }
}