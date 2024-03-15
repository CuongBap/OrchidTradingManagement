using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class EditOrchid
    {
        [Required]
        public Guid OrchidId { get; set; }
        [Required]
        public string OrchidName { get; set; } = null!;
        [Required]
        public string Characteristic { get; set; } = null!;
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
