using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<CustomerEntity?>;

