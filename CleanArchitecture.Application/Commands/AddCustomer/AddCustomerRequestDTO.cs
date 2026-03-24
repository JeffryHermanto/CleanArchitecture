namespace CleanArchitecture.Application.Commands.AddCustomer;

public record AddCustomerRequestDTO(
    string Name,
    string Email,
    string Phone);
