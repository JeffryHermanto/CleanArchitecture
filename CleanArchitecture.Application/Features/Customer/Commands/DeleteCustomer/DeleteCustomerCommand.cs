
using CleanArchitecture.Application.Utilities.SimpleMediator;

namespace CleanArchitecture.Application.Commands.DeleteCustomer;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest<bool>;

