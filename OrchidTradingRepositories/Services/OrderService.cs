using CloudinaryDotNet.Actions;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _iOrderRepository = null;

        public OrderService()
        {
            _iOrderRepository = new OrderRepository();
        }

        public Task<Order> AddAsync(Order order)
        {
            return _iOrderRepository.AddAsync(order);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _iOrderRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return _iOrderRepository.GetAllAsync();
        }

        public Task<Order> GetAsync(Guid id)
        {
            return _iOrderRepository.GetAsync(id);
        }

        public Task<bool> UpdateAsync(Order order)
        {
            return _iOrderRepository.UpdateAsync(order);
        }
    }
}
