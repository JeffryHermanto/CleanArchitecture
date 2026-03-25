using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<CustomerEntity?>;

