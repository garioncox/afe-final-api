using afe_final_api.data.DTO;
using afe_final_api.Data;
using afe_final_api.services;
using Microsoft.AspNetCore.Mvc;

namespace afe_final_api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TransactionEventController : ControllerBase
{
    private readonly ITransactionEventService _transactionEventService;
    public TransactionEventController(ITransactionEventService service)
    {
        _transactionEventService = service;
    }

    [HttpGet("getAll")]
    public async Task<List<TransactionEvent>> GetTransactionsAsync()
    {
        return await _transactionEventService.GetAllTransactionEvents();
    }

    [HttpGet("get/{email}")]
    public async Task<List<TransactionEvent>> GetTransactionsByEmailAsync(string email)
    {
        return await _transactionEventService.GetTransactionsByEmailAsync(email);
    }

    [HttpPost("add")]
    public async Task<int> AddTransactionEvent([FromBody] TransactionEventDTO dto)
    {
        TransactionEvent transactionEvent = new()
        {
            Amt = dto.amt,
            TransactionDate = dto.transactionDate,
            TransactionName = dto.transactionName,
            CustomerId = dto.customerId,
        };

        await _transactionEventService.AddTransactionEvent(transactionEvent);
        return transactionEvent.Id;
    }
}
