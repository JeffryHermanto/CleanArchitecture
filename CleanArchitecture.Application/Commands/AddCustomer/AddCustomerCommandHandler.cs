using CleanArchitecture.Application.Utilities.SimpleMediator;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Commands.AddCustomer;

public class AddCustomerCommandHandler(
    ICustomerRepository customerRepository,
    ILogger<AddCustomerCommandHandler> logger)
    : IRequestHandler<AddCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(AddCustomerCommand request)
    {
        logger.LogInformation(
            "Creating new customer with Email {Email}",
            request.AddCustomerRequestDTO.Email
        );

        try
        {
            var customer = new CustomerEntity(
                request.AddCustomerRequestDTO.Name,
                request.AddCustomerRequestDTO.Email,
                request.AddCustomerRequestDTO.Phone
            );

            var result = await customerRepository.AddCustomerAsync(customer);

            logger.LogInformation(
                "Customer created successfully with ID {CustomerId}",
                result.Id
            );

            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error creating customer with Email {Email}",
                request.AddCustomerRequestDTO.Email
            );
            throw;
        }
    }
}