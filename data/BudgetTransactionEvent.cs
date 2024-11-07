using System;
using System.Collections.Generic;

namespace afe_final_api.Data;

public partial class BudgetTransactionEvent
{
    public int Id { get; set; }

    public int TransactionEventId { get; set; }

    public int BudgetId { get; set; }

    public virtual Budget Budget { get; set; } = null!;

    public virtual TransactionEvent TransactionEvent { get; set; } = null!;
}
