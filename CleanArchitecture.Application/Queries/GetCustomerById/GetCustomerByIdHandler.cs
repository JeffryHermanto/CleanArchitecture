using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler(
    ICustomerRepository customerRepository,
    ILogger<GetCustomerByIdQueryHandler> logger)
    : IRequestHandler<GetCustomerByIdQuery, CustomerEntity?>
{
    public async Task<CustomerEntity?> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching customer with ID {CustomerId}", request.CustomerId);

        try
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.CustomerId);

            if (customer is null)
            {
                logger.LogWarning("Customer with ID {CustomerId} not found", request.CustomerId);
                return null;
            }

            logger.LogInformation("Successfully fetched customer with ID {CustomerId}", request.CustomerId);

            return customer;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching customer with ID {CustomerId}", request.CustomerId);
            throw;
        }
    }
}