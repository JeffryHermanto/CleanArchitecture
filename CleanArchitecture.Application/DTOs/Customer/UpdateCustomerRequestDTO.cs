namespace CleanArchitecture.Application.DTOs.Customer
{
    public record UpdateCustomerRequestDTO(
        string Name,
        string Email,
        string Phone);
}