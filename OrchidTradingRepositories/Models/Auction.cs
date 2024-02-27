using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class Auction
{
    public Guid AuctionId { get; set; }

    public string AuctionName { get; set; } = null!;

    public decimal? Deposit { get; set; }

    public decimal StartingBid { get; set; }

    public DateTime OpenDate { get; set; }

    public DateTime CloseDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Bidding> Biddings { get; set; } = new List<Bidding>();

    public virtual ICollection<ListInformation> ListInformations { get; set; } = new List<ListInformation>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
