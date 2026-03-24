namespace CleanArchitecture.Domain.Entities;

public class CustomerEntity(string name, string email, string phone)
{
    public Guid Id { get; set; }
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Phone { get; set; } = phone;
}
