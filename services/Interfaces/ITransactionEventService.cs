using afe_final_api.Data;

namespace afe_final_api.services;

public interface ITransactionEventService
{
    Task<List<TransactionEvent>> GetAllTransactionEvents();
    Task AddTransactionEvent(TransactionEvent transactionEvent);
}