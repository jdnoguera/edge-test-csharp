using backend_test.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_test.Services;

public class CustomerService : ICustomerService
{
    private readonly DBContext _dbContext;

    public CustomerService(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Customer>> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken)
    {   
        try
        {
            return _dbContext.Customer
                .Skip(pageIndex*pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            throw new QueryException("Cannot return customers", e);
        }
    }
    
    public async Task<Customer?> GetById(int id, CancellationToken cancellationToken)
    {   
        try
        {
            return await _dbContext.Customer
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            throw new QueryException("Cannot return customer", e);
        }
    }
    
    public async Task CreateCustomer(CreateOrUpdateCustomerModel model, CancellationToken cancellationToken)
    {
        try
        {
            var customer = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DocumentNumber = model.DocumentNumber
            };

            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new QueryException("Cannot create customer", e);
        }
    }
    
    public async Task Update(int id, CreateOrUpdateCustomerModel model, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _dbContext.Customer
                .FirstAsync(c => c.Id == id, cancellationToken: cancellationToken);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.DocumentNumber = model.DocumentNumber;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new QueryException("Cannot update customer", e);
        }
    }

    public async Task DeleteById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _dbContext.Customer
                .FirstAsync(c => c.Id == id, cancellationToken: cancellationToken);
            _dbContext.Customer.Remove(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new QueryException("Cannot delete customer", e);
        }
    }
    
}