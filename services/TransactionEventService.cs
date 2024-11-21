using afe_final_api.Data;
using Microsoft.EntityFrameworkCore;

namespace afe_final_api.services;

public class TransactionEventService : ITransactionEventService
{
    readonly PostgresContext _context;
    public TransactionEventService(PostgresContext context)
    {
        _context = context;
    }

    public async Task<List<TransactionEvent>> GetAllTransactionEvents()
    {
        return await _context.TransactionEvents.ToListAsync();
    }

    public async Task AddTransactionEvent(TransactionEvent transactionEvent)
    {
        _context.TransactionEvents.Add(transactionEvent);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TransactionEvent>> GetTransactionsByEmailAsync(string email)
    {
        return await _context.TransactionEvents
            .Include(t => t.Customer)
            .Where(t => t.Customer!.Email == email)
            .ToListAsync();
    }
}