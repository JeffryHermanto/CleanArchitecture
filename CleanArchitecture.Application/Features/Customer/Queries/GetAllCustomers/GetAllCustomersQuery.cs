using CleanArchitecture.Application.Utilities.SimpleMediator;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Queries.GetAllCustomers;

public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerEntity>>;

