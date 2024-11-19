namespace afe_final_api.data.DTO;

public class TransactionEventDTO
{
    public required decimal amt { get; set; }
    public required string transactionDate { get; set; }
    public required string transactionName { get; set; }
    public required int customerId { get; set; }
}