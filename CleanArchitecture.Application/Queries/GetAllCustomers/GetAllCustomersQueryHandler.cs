using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler(
    ICustomerRepository customerRepository,
    ILogger<GetAllCustomersQueryHandler> logger)
    : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>
{
    public async Task<IEnumerable<CustomerEntity>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all customers");

        try
        {
            var customers = await customerRepository.GetCustomers();

            logger.LogInformation("Successfully fetched {Count} customers", customers.Count());

            return customers;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while fetching customers");
            throw;
        }
    }
}