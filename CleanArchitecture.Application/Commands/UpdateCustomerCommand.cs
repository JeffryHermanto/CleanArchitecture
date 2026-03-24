using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record UpdateCustomerRequestDTO(
    string Name,
    string Email,
    string Phone);

public record UpdateCustomerCommand(Guid customerId, UpdateCustomerRequestDTO UpdateCustomerRequestDTO) : IRequest<CustomerEntity>;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CustomerEntity(
                 request.UpdateCustomerRequestDTO.Name,
                 request.UpdateCustomerRequestDTO.Email,
                 request.UpdateCustomerRequestDTO.Phone
             );


        return await customerRepository.UpdateCustomerByAsync(request.customerId, customer);
    }
}