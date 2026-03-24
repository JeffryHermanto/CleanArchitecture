using MediatR;

namespace CleanArchitecture.Application.Commands;

public record DeleteCustomerCommand(Guid CustomerId) : IRequest<bool>;

