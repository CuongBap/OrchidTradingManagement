using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetAsync(Guid id);
        Task<Order> AddAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(Guid id);
    }
}
