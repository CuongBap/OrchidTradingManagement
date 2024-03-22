using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class ListOrderDetail
    {

        public Guid OrderDetailId { get; set; }

        public Guid? OrderId {get; set; }

        public Guid? OrchidId { get; set; }
        
        public string OrchidName {  get; set; }
        
        public string Characteristic {  get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }

       

    }
}
