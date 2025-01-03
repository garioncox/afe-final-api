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

    [HttpPost("add")]
    public async Task AddBudgetAsync(BudgetDTO dto)
    {
        Budget budget = new()
        {
            BudgetName = dto.budgetName,
            CustomerId = dto.customerId
        };

        await _budgetService.AddBudgetAsync(budget);
    }

    [HttpPut("edit")]
    public async Task EditBudgetAsync(BudgetDTO dto)
    {
        if (dto.id == null)
        {
            return;
        }

        Budget budget = new()
        {
            Id = dto.id.Value,
            BudgetName = dto.budgetName,
            CustomerId = dto.customerId
        };

        await _budgetService.EditBudgetAsync(budget);
    }
}
