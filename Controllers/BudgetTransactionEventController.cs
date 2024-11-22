using afe_final_api.data.DTO;
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
    public async Task AddBudgetTransactionEvent([FromBody] BudgetTransactionEventDTO dto)
    {
        BudgetTransactionEvent bte = new()
        {
            TransactionEventId = dto.transactionEventId,
            BudgetId = dto.budgetId,
        };

        await _budgetTransactionEventService.AddBudgetTransactionEvent(bte);
    }

    [HttpGet("get/{customerId}")]
    public async Task<List<BudgetTransactionEvent>> GetAllBudgetTransactionEventForCustomer(int customerId) {
        return await _budgetTransactionEventService.GetAllBudgetTransactionEventForCustomer(customerId);
    }
}
