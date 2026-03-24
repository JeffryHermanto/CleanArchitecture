using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record UpdateCustomerCommand(Guid customerId, CustomerEntity customer) : IRequest<CustomerEntity>;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await customerRepository.UpdateCustomerByAsync(request.customerId, request.customer);
    }
}