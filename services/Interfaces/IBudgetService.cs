using afe_final_api.Data;

namespace afe_final_api.services;

public interface IBudgetService
{
    Task<List<Budget>> GetAllBudgetsAsync();
    Task<List<Budget>> GetBudgetsByCustomerAsync(int id);
}