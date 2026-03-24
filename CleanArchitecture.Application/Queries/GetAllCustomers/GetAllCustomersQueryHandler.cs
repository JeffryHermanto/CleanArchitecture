using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>
{
    public async Task<IEnumerable<CustomerEntity>> Handle(
        GetAllCustomersQuery request,
        CancellationToken cancellationToken)
    {
        return await customerRepository.GetCustomers();
    }
}