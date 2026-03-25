using MediatR;

namespace CleanArchitecture.Application.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest<bool>;

