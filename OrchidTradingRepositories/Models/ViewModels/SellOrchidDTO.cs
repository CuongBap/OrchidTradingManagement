using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class SellOrchidDTO
    {
        public Guid InforId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; } = null!;

        public Guid? UserId { get; set; }
        public Guid? OrchidId { get; set; }
        public string OrchidName { get; set; } = null!;

        public string Characteristic { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
