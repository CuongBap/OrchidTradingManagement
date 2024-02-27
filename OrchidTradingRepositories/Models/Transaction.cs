using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class Transaction
{
    public Guid TransactionId { get; set; }

    public Guid OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
