using afe_final_api.Data;
using afe_final_api.services;
using Microsoft.AspNetCore.Mvc;

namespace afe_final_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BudgetTransactionEventController : ControllerBase
{
    private readonly IBudgetTransactionEventService _budgetTransactionEventService;
    public BudgetTransactionEventController(IBudgetTransactionEventService service)
    {
        _budgetTransactionEventService = service;
    }

    [HttpPost("add")]
    public async Task AddTransactionEvent(BudgetTransactionEvent bte)
    {
        await _budgetTransactionEventService.AddBudgetTransactionEvent(bte);
    }
}
