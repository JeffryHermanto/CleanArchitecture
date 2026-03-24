using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Customers;User ID=SA;Password=P@ssw0rd;Encrypt=True;Trust Server Certificate=True");
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
