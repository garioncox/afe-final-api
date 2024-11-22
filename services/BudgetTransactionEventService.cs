using afe_final_api.Data;
using afe_final_api.services;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<BudgetTransactionEvent>> GetAllBudgetTransactionEventForCustomer(int customerId)
    {
        return await _context.BudgetTransactionEvents
            .Include(bte => bte.Budget)
            .Where(bte => bte.Budget.CustomerId == customerId)
            .ToListAsync();
    }
}