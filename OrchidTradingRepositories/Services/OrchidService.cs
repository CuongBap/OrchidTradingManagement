using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class OrchidService : IOrchidService
    {
        private readonly IOrchidRepository iOrchidRepository = null;

        public OrchidService()
        {
            iOrchidRepository = new OrchidRepository();
        }

        public Task<OrchidProduct> AddAsync(OrchidProduct orchid)
        {
            return iOrchidRepository.AddAsync(orchid);
        }

        public Task<OrchidProduct> GetAsync(Guid id)
        {
            return iOrchidRepository.GetAsync(id);
        }

        public Task<bool> UpdateAdminAsync(OrchidProduct orchid)
        {
            return iOrchidRepository.UpdateAdminAsync(orchid);
        }

        public Task<bool> UpdateAsync(OrchidProduct orchid)
        {
            return iOrchidRepository.UpdateAsync(orchid);
        }
    }
}
