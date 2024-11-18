using afe_final_api.Data;
using afe_final_api.services;

public class BudgetTransactionEventService : IBudgetTransactionEventService
{
    readonly PostgresContext _context;
    public BudgetTransactionEventService(PostgresContext context)
    {
        _context = context;
    }

    public async Task AddBudgetTransactionEvent(BudgetTransactionEvent bte)
    {
        _context.BudgetTransactionEvents.Add(bte);
        await _context.SaveChangesAsync();
    }
}