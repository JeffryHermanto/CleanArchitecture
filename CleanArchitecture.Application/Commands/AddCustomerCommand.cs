using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record AddCustomerCommand(CustomerEntity Customer) : IRequest<CustomerEntity>;

public class AddCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<AddCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        return await customerRepository.AddCustomerByIdAsync(request.Customer);
    }
}

