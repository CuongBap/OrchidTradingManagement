using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class ListInformation
{
    public Guid InforId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string Status { get; set; } = null!;

    public Guid? OrchidId { get; set; }

    public Guid? AuctionId { get; set; }

    public Guid? UserId { get; set; }

    public virtual Auction? Auction { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual OrchidProduct? Orchid { get; set; }

    public virtual User? User { get; set; }
}
