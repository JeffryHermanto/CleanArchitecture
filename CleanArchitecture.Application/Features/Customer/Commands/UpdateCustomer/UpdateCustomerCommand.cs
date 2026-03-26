using CleanArchitecture.Application.Commands.UpdateCustomer;
using CleanArchitecture.Application.DTOs.Customer;
using CleanArchitecture.Application.Utilities.SimpleMediator;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Commands;

public record UpdateCustomerCommand(
    Guid CustomerId,
    UpdateCustomerRequestDTO UpdateCustomerRequestDTO
    ) : IRequest<CustomerEntity>;

