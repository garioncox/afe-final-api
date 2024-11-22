using afe_final_api.data.DTO;
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

    [HttpGet("getAllAuth")]
    public async Task<List<Budget>> GetAllBudgetsAuthAsync()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return await _budgetService.GetAllBudgetsAsync();
        }
        return [];
    }

    [HttpGet("get/{id}")]
    public async Task<List<Budget>> GetBudgetsByCustomerAsync(int id)
    {
        return await _budgetService.GetBudgetsByCustomerAsync(id);
    }

    [HttpGet("add")]
    public async Task AddBudgetAsync(BudgetDTO dto)
    {
        Budget budget = new()
        {
            BudgetName = dto.BudgetName,
            CustomerId = dto.CustomerId
        };

        await _budgetService.AddBudgetAsync(budget);
    }
}
