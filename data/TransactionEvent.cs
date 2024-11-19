using System;
using System.Collections.Generic;

namespace afe_final_api.Data;

public partial class TransactionEvent
{
    public int Id { get; set; }

    public decimal? Amt { get; set; }

    public string TransactionDate { get; set; } = null!;

    public string? TransactionName { get; set; }

    public int? CustomerId { get; set; }

    public virtual ICollection<BudgetTransactionEvent> BudgetTransactionEvents { get; set; } = new List<BudgetTransactionEvent>();

    public virtual Customer? Customer { get; set; }
}
