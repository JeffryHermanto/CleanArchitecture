using CleanArchitecture.Application.Commands.DeleteCustomer;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId tidak valid");
    }
}
