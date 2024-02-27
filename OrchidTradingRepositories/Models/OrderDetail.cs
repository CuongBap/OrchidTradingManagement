using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public Guid? OrchidId { get; set; }

    public Guid? OrderId { get; set; }

    public virtual OrchidProduct? Orchid { get; set; }

    public virtual Order? Order { get; set; }
}
