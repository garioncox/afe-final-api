using afe_final_api.Data;
using Microsoft.EntityFrameworkCore;

namespace afe_final_api.services;

public class CustomerService : ICustomerService
{
    readonly PostgresContext _context;
    public CustomerService(PostgresContext context)
    {
        _context = context;
    }


    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        return await _context.Customers
            .Where(c => c.Email == email)
            .FirstOrDefaultAsync();
    }
}