using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainDI(this IServiceCollection services)
    {
        return services;
    }
}
