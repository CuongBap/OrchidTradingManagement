using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public interface IAuctionService
    {
        Task<Auction> GetAsync(Guid id);
        Task<Auction> AddAsync(Auction auction);
        Task<bool> UpdateAsync(Auction auction);
    }
}
