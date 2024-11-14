using afe_final_api.Data;
using Microsoft.EntityFrameworkCore;

namespace afe_final_api.services;

public class BudgetService : IBudgetService
{
    readonly PostgresContext _context;
    public BudgetService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<List<Budget>> GetAllBudgetsAsync()
    {
        return await _context.Budgets.ToListAsync();
    }

    public async Task<List<Budget>> GetBudgetsByCustomerAsync(int id)
    {
        return await _context.Budgets
            .Where(b => b.CustomerId == id)
            .ToListAsync();
    }
}