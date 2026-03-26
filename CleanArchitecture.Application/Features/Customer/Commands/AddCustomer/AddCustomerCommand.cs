using CleanArchitecture.Application.DTOs.Customer;
using CleanArchitecture.Application.Utilities.SimpleMediator;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Commands;

public record AddCustomerCommand(AddCustomerRequestDTO AddCustomerRequestDTO) : IRequest<CustomerEntity>;
