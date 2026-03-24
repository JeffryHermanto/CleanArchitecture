using CleanArchitecture.Application.Commands.AddCustomer;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public record AddCustomerCommand(AddCustomerRequestDTO AddCustomerRequestDTO) : IRequest<CustomerEntity>;
