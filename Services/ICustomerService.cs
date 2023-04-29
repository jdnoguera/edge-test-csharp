using edge_test_csharp.Infrastructure;
using edge_test_csharp.Models;

namespace edge_test_csharp.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetAll(int pageIndex, int pageSize, CancellationToken cancellationToken);
    Task<Customer?> GetById(int id, CancellationToken cancellationToken);
    Task CreateCustomer(CreateOrUpdateCustomerModel model, CancellationToken cancellationToken);
    Task Update(int id, CreateOrUpdateCustomerModel model, CancellationToken cancellationToken);
    Task DeleteById(int id, CancellationToken cancellationToken);
}