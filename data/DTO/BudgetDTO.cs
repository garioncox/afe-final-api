namespace afe_final_api.data.DTO;

public class BudgetDTO
{
    public required string budgetName { get; set; } = null!;
    public required int customerId { get; set; }
}