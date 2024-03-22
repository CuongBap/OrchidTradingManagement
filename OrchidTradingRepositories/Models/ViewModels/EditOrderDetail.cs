using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class EditOrderDetail
    {
        public Guid OrderDetailId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Guid? OrchidId { get; set; }

        public Guid? OrderId { get; set; }
    }
}
