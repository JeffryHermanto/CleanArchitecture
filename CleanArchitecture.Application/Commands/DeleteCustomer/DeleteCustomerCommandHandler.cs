using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        return await customerRepository.DeleteCustomerAsync(request.CustomerId);
    }
}