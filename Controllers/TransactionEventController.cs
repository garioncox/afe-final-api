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
}
