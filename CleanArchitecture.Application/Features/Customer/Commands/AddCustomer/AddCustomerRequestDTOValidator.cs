using CleanArchitecture.Application.DTOs.Customer;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Customer.Commands.AddCustomer

{
    public class AddCustomerRequestDTOValidator : AbstractValidator<AddCustomerRequestDTO>
    {
        public AddCustomerRequestDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name wajib diisi")
                .MaximumLength(100).WithMessage("Name maksimal 100 karakter");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email wajib diisi")
                .EmailAddress().WithMessage("Format email tidak valid");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone wajib diisi")
                .Matches(@"^\+?\d{9,15}$")
                .WithMessage("Format phone tidak valid (9-15 digit, boleh diawali +)");
        }
    }
}