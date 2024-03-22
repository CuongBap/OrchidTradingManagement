using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingServices
{
    public class OrderDetailService : IOrderDetailService
    {
        public readonly OrchidTradingManagementContext _dbContext = new();
        public Task<OrderDetail> AddSync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid orderDetailId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return await _dbContext.OrderDetails.ToListAsync();
        }

        public Task<OrderDetail> GetAsync(Guid orderDetailId)
        {
            var orderDetails = _dbContext.OrderDetails.Where(od => od.OrderDetailId == orderDetailId).FirstOrDefaultAsync();
            return orderDetails;
        }

        public Task<bool> UpdateAsync(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
