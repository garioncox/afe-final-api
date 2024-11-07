using afe_final_api.Data;
using afe_final_api.services;
using Microsoft.AspNetCore.Mvc;

namespace afe_final_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService service)
    {
        _customerService = service;
    }


    [HttpGet("getAll")]
    public async Task<List<Customer>> GetEmployeeListAsync()
    {
        return await _customerService.GetAllCustomers();
    }
}
