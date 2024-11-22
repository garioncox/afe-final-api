using afe_final_api.Data;

namespace afe_final_api.services;

public interface IBudgetTransactionEventService
{
    Task AddBudgetTransactionEvent(BudgetTransactionEvent bte);
    Task<List<BudgetTransactionEvent>> GetAllBudgetTransactionEventForCustomer(int customerId);
}