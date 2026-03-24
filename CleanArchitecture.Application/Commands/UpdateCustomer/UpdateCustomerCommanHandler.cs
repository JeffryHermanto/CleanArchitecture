using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
{
    public async Task<CustomerEntity> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customer = new CustomerEntity(
                 request.UpdateCustomerRequestDTO.Name,
                 request.UpdateCustomerRequestDTO.Email,
                 request.UpdateCustomerRequestDTO.Phone
             );


        return await customerRepository.UpdateCustomerByAsync(request.CustomerId, customer);
    }
}