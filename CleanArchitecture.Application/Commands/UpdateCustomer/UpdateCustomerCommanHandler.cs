using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    ILogger<UpdateCustomerCommandHandler> logger)
    : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Updating customer with ID {CustomerId}",
            request.CustomerId
        );

        try
        {
            var customer = new CustomerEntity(
                request.UpdateCustomerRequestDTO.Name,
                request.UpdateCustomerRequestDTO.Email,
                request.UpdateCustomerRequestDTO.Phone
            );

            var updatedCustomer = await customerRepository.UpdateCustomerByAsync(
                request.CustomerId,
                customer
            );

            logger.LogInformation(
                "Customer with ID {CustomerId} updated successfully",
                request.CustomerId
            );

            return updatedCustomer;
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error updating customer with ID {CustomerId}",
                request.CustomerId
            );
            throw;
        }
    }
}