using afe_final_api.Data;
using afe_final_api.services;
using Microsoft.AspNetCore.Mvc;

namespace afe_final_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
    private readonly IBudgetService _budgetService;
    public BudgetController(IBudgetService service)
    {
        _budgetService = service;
    }


    [HttpGet("getAll")]
    public async Task<List<Budget>> GetAllBudgetsAsync()
    {
        return await _budgetService.GetAllBudgetsAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<List<Budget>> GetBudgetsByCustomerAsync(int id)
    {
        return await _budgetService.GetBudgetsByCustomerAsync(id);
    }
}
