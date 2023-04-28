using backend_test.Models;

namespace backend_test.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken);
    Task<Customer?> GetById(int id, CancellationToken cancellationToken);
    Task CreateCustomer(CreateOrUpdateCustomerModel model, CancellationToken cancellationToken);
    Task Update(int id, CreateOrUpdateCustomerModel model, CancellationToken cancellationToken);
    Task DeleteById(int id, CancellationToken cancellationToken);
}