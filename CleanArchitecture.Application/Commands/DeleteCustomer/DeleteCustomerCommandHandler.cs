using CleanArchitecture.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(
    ICustomerRepository customerRepository,
    ILogger<DeleteCustomerCommandHandler> logger)
    : IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Deleting customer with ID {CustomerId}",
            request.CustomerId
        );

        try
        {
            var success = await customerRepository.DeleteCustomerAsync(request.CustomerId);

            if (!success)
            {
                logger.LogWarning(
                    "Customer with ID {CustomerId} not found or already deleted",
                    request.CustomerId
                );
                return false;
            }

            logger.LogInformation(
                "Customer with ID {CustomerId} deleted successfully",
                request.CustomerId
            );

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error deleting customer with ID {CustomerId}",
                request.CustomerId
            );
            throw;
        }
    }
}