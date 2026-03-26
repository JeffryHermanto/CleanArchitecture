using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.DTOs.Customer;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerRequestDTOValidator : AbstractValidator<UpdateCustomerRequestDTO>
{
    public UpdateCustomerRequestDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name wajib diisi")
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email wajib diisi")
            .EmailAddress();

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone wajib diisi")
            .Matches(@"^\+?\d{9,15}$")
            .WithMessage("Format phone tidak valid");
    }
}
