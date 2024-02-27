using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class Bidding
{
    public Guid BidId { get; set; }

    public decimal? TotalBid { get; set; }

    public Guid? AuctionId { get; set; }

    public Guid? RegisterId { get; set; }

    public virtual Auction? Auction { get; set; }

    public virtual RegisterAuction? Register { get; set; }
}
