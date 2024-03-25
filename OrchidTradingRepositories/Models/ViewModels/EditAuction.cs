using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class EditAuction
    {
        [Required]
        public Guid AuctionId { get; set; }
        [Required]
        public string AuctionName { get; set; } = null!;
        [Required]
        [Range(0, 50000000), DataType(DataType.Currency)]
        //trước dấu "," lấy 18 số, sau dấu "," lấy 2 số
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Deposit { get; set; }
        [Required]
        [Range(0, 50000000), DataType(DataType.Currency)]
        //trước dấu "," lấy 18 số, sau dấu "," lấy 2 số
        [Column(TypeName = "decimal(18, 2)")]
        public decimal StartingBid { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
    }
}
