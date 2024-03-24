using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public interface IOrchidService
    {
        Task<OrchidProduct> GetAsync(Guid id);
        Task<OrchidProduct> AddAsync(OrchidProduct orchid);
        Task<bool> UpdateAsync(OrchidProduct orchid);
        Task<bool> UpdateAdminAsync(OrchidProduct orchid);
    }
}
