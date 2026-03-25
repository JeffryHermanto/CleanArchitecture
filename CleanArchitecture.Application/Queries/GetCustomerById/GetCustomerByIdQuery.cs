using CleanArchitecture.Application.Utilities.SimpleMediator;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<CustomerEntity?>;

