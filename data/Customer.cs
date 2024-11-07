using System;
using System.Collections.Generic;

namespace afe_final_api.Data;

public partial class Customer
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<TransactionEvent> TransactionEvents { get; set; } = new List<TransactionEvent>();
}
