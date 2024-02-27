using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class AddAuction
    {
        [Required]
        public string AuctionName { get; set; } = null!;
        [Required]
        public decimal? Deposit { get; set; }
        [Required]
        public decimal StartingBid { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
        [Required]
        public string Status { get; set; } = null!;
    }
}
