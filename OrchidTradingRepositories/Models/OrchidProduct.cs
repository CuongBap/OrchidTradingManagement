using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class OrchidProduct
{
    public Guid OrchidId { get; set; }

    public string OrchidName { get; set; } = null!;

    public string Characteristic { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<ListInformation> ListInformations { get; set; } = new List<ListInformation>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
