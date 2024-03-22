using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingServices
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail> GetAsync(Guid orderDetailId);
        Task<OrderDetail> AddSync(OrderDetail orderDetail);
        Task<bool> UpdateAsync(OrderDetail orderDetail);
        Task<bool> DeleteAsync(Guid orderDetailId);
    }
}
