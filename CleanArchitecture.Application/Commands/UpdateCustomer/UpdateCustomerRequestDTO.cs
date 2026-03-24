namespace CleanArchitecture.Application.Commands.UpdateCustomer;

public record UpdateCustomerRequestDTO(
    string Name,
    string Email,
    string Phone);