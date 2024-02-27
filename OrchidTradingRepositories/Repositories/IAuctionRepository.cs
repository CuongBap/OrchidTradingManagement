using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public interface IAuctionRepository
    {
        Task<Auction> GetAsync(Guid id);
        Task<Auction> AddAsync(Auction auction);
        Task<bool> UpdateAsync(Auction auction);
    }
}
