using System;
using System.Collections.Generic;

namespace afe_final_api.Data;

public partial class Budget
{
    public int Id { get; set; }

    public string BudgetName { get; set; } = null!;

    public int? SubcategoryOf { get; set; }

    public int CustomerId { get; set; }

    public virtual ICollection<BudgetTransactionEvent> BudgetTransactionEvents { get; set; } = new List<BudgetTransactionEvent>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Budget> InverseSubcategoryOfNavigation { get; set; } = new List<Budget>();

    public virtual Budget? SubcategoryOfNavigation { get; set; }
}
