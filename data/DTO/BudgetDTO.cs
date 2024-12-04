namespace afe_final_api.data.DTO;

public class BudgetDTO
{
    public int? id { get; set; }
    public required string budgetName { get; set; }
    public required int customerId { get; set; }
}