using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class EditListInformation
    {
        [Required]
        public Guid InforId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Image { get; set; } = null!;
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Status { get; set; } = null!;

        public Guid? OrchidId { get; set; }
        public Guid? AuctionId { get; set; }
        public Guid? UserId { get; set; }
    }
}
