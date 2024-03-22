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
    public class OrderRepository : IOrderRepository
    {
        private readonly OrchidTradingManagementContext _dbContext = new();
        public static OrderRepository Instance { get; private set; }

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
            var orders = await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
            return orders;
        }
        public async Task<bool> UpdateAsync(Order orders)
        {
            var existedOrders = await _dbContext.Orders.FindAsync(orders.OrderId);
            if (existedOrders != null)
            {
                existedOrders.OrderId = orders.OrderId;
                existedOrders.OrderDate = orders.OrderDate;
                existedOrders.Status = orders.Status;
                existedOrders.Total = orders.Total;
            }    
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            } 
            return false;
        }

       
    }
}
