using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
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

        public async Task<List<ListOrderDetail>> GetAllListOrderDetailAsync()
        {
            var result = await _dbContext.OrderDetails.Select(x => new ListOrderDetail
            {
                OrderDetailId = x.OrderDetailId,
                OrderId = x.OrderId,
                OrchidId = x.OrchidId,
                OrchidName = x.Orchid.OrchidName,
                Characteristic = x.Orchid.Characteristic,
                UnitPrice = x.Orchid.UnitPrice,
                Quantity = x.Orchid.Quantity
            }).OrderByDescending(x => x.Quantity).ToListAsync();
            return result;
        }

        public async Task<OrderDetail> GetAsync(Guid orderDetailId)
        {
            return  await _dbContext.OrderDetails.Where(od => od.OrderDetailId == orderDetailId).FirstOrDefaultAsync();
            
        }

        public async Task<bool> UpdateAsync(OrderDetail orderDetail)
        {
            var orderDetails = await _dbContext.OrderDetails.FindAsync(orderDetail.OrderId);
            if (orderDetails != null)
            {
                orderDetails.OrderDetailId = orderDetail.OrderDetailId;
                orderDetails.UnitPrice = orderDetail.UnitPrice;
                orderDetails.Quantity = orderDetail.Quantity;
                orderDetails.OrchidId = orderDetail.OrchidId;
                orderDetails.OrderId = orderDetail.OrderId;
                var result = await _dbContext.SaveChangesAsync();
                if(result > 0)
                {
                    return true;

                }
            }
            return false;
        }

        
    }
}
