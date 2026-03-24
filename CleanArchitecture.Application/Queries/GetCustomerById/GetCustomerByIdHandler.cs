using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetCustomerByIdQuery, CustomerEntity?>
{
    public async Task<CustomerEntity?> Handle(
        GetCustomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await customerRepository.GetCustomerByIdAsync(request.CustomerId);
    }
}