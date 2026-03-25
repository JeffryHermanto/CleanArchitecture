using System.Reflection;
using CleanArchitecture.Application.Utilities.SimpleMediator;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<IMediator, SimpleMediator>();
        services.AddRequestHandlersFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
