using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrchidTradingManagementContext _dbContext = new();

        public async Task<Order> AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetAsync(Guid id)
        {
            var orders = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            return orders;
        }
        public async Task<bool> UpdateAsync(Order order)
        {
            var existedOrders = await _dbContext.Orders.FindAsync(order.OrderId);
            if(existedOrders != null)
            {
                if(existedOrders.BuyerId.Equals(existedOrders.SellerId))
                {
                    return false;
                }
                else
                {
                    existedOrders.OrderId = order.OrderId;
                    existedOrders.Status = order.Status;
                }
            }
            var result = await _dbContext.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            } return false;
        }
    }
}
