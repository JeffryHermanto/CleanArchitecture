using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public record GetAllCustomersQuery : IRequest<IEnumerable<CustomerEntity>>;

