using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext dbContext) : ICustomerRepository
{
    public async Task<IEnumerable<CustomerEntity>> GetCustomers()
    {
        return await dbContext.Customers.ToListAsync();
    }

    public async Task<CustomerEntity?> GetCustomerByIdAsync(Guid id)
    {
        return await dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CustomerEntity> AddCustomerAsync(CustomerEntity entity)
    {
        entity.Id = Guid.NewGuid();
        dbContext.Customers.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<CustomerEntity> UpdateCustomerByAsync(Guid id, CustomerEntity entity)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

        if (customer is not null)
        {
            customer.Name = entity.Name;
            customer.Email = entity.Email;
            customer.Phone = entity.Phone;

            await dbContext.SaveChangesAsync();

            return customer;
        }

        return entity;
    }

    public async Task<bool> DeleteCustomerAsync(Guid customerId)
    {
        var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.Id == customerId);

        if (customer is not null)
        {
            dbContext.Customers.Remove(customer);
            return await dbContext.SaveChangesAsync() > 0;
        }

        return false;
    }
}
