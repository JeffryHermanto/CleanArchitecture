using CleanArchitecture.Application.Commands.UpdateCustomer;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record UpdateCustomerCommand(
    Guid CustomerId,
    UpdateCustomerRequestDTO UpdateCustomerRequestDTO
    ) : IRequest<CustomerEntity>;

