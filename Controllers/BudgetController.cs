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
    public async Task<List<Budget>> GetBudgetsAsync()
    {
        return await _budgetService.GetAllBudgets();
    }
}
