using edge_test_csharp.Infrastructure;
using edge_test_csharp.Models;
using edge_test_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace edge_test_csharp.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> Get(CancellationToken cancellationToken, int pageIndex = 0, int pageSize = 5)
    {
        return Ok(await _service.GetAll(pageIndex, pageSize, cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id, CancellationToken cancellationToken)
    {
        var customer = await _service.GetById(id, cancellationToken);
        return customer is null ? NotFound() : Ok(customer);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Customer>>> Create(CreateOrUpdateCustomerModel model, CancellationToken cancellationToken)
    {
        await _service.CreateCustomer(model, cancellationToken);
        return StatusCode(201);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, CreateOrUpdateCustomerModel model,CancellationToken cancellationToken)
    {
        await _service.Update(id, model, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        await _service.DeleteById(id, cancellationToken);
        return Ok();
    }
 }