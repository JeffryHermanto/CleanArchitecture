using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record AddCustomerRequestDTO(
    string Name,
    string Email,
    string Phone);

public record AddCustomerCommand(AddCustomerRequestDTO AddCustomerRequestDTO) : IRequest<CustomerEntity>;

public class AddCustomerCommandHandler(ICustomerRepository customerRepository) : IRequestHandler<AddCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CustomerEntity(
            request.AddCustomerRequestDTO.Name,
            request.AddCustomerRequestDTO.Email,
            request.AddCustomerRequestDTO.Phone
        );

        return await customerRepository.AddCustomerAsync(customer);
    }
}

