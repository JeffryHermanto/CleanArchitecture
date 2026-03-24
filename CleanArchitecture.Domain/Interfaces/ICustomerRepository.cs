using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetCustomers();
    Task<CustomerEntity?> GetCustomerByIdAsync(Guid id);
    Task<CustomerEntity> AddCustomerAsync(CustomerEntity entity);
    Task<CustomerEntity> UpdateCustomerByAsync(Guid id, CustomerEntity entity);
    Task<bool> DeleteCustomerAsync(Guid customerId);

}
