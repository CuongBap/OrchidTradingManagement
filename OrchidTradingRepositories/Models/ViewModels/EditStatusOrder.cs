using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class EditStatusOrder
    {
        public Guid OrderDetailId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Guid? OrchidId { get; set; }
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = null!;

        public decimal Total { get; set; }

        public Guid? BuyerId { get; set; }

        public Guid? SellerId { get; set; }

        public Guid? AuctionId { get; set; }

    }
}
