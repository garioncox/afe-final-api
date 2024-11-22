namespace afe_final_api.data.DTO;

public class BudgetDTO
{
    public required string BudgetName { get; set; } = null!;
    public required int CustomerId { get; set; }
}