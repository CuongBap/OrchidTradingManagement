using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly  IOrderDetailRepository iOrderDetailRepository = null;

        public OrderDetailService()
        {
            iOrderDetailRepository = new OrderDetailRepository();
        }
        public Task<OrderDetail> AddSync(OrderDetail orderDetail)
        {
           return iOrderDetailRepository.AddSync(orderDetail);
        }

        public Task<bool> DeleteAsync(Guid orderDetailId)
        {
            return iOrderDetailRepository.DeleteAsync(orderDetailId);
        }

        public Task<IEnumerable<OrderDetail>> GetAllAsync()
        {
            return iOrderDetailRepository.GetAllAsync();
        }

        public Task<OrderDetail> GetAsync(Guid orderDetailId)
        {
            return iOrderDetailRepository.GetAsync(orderDetailId);
        }

        public Task<bool> UpdateAsync(OrderDetail orderDetail)
        {
            return iOrderDetailRepository.UpdateAsync(orderDetail);
        }
    }
}
