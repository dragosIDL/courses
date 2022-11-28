using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configure;

public static class Configuration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}