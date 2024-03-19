using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class AuctionOrchidDTO
    {
        public Guid InforId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; } = null!;

        public Guid? UserId { get; set; }
        public Guid? AuctionId { get; set; }

        public string AuctionName { get; set; } = null!;

        public decimal? Deposit { get; set; }

        public decimal StartingBid { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }
    }
}
