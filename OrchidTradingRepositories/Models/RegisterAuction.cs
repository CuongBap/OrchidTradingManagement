using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class RegisterAuction
{
    public Guid RegisterId { get; set; }

    public decimal? Price { get; set; }

    public Guid? UserId { get; set; }

    public virtual ICollection<Bidding> Biddings { get; set; } = new List<Bidding>();

    public virtual User? User { get; set; }
}
