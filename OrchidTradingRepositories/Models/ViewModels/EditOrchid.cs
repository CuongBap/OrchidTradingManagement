using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(0, 50000000), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Required]
        [Range(1, 10000), DataType(DataType.Currency)]
        public int Quantity { get; set; }
    }
}
