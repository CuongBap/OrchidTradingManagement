using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public interface IOrchidRepository
    {
        Task<OrchidProduct> GetAsync(Guid id);
        Task<OrchidProduct> AddAsync(OrchidProduct orchid);
        Task<bool> UpdateAsync(OrchidProduct orchid);
    }
}
