using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository iAuctionRepo= null;

        public AuctionService()
        {
            iAuctionRepo = new AuctionRepository();
        }

        public Task<Auction> AddAsync(Auction auction)
        {
            return iAuctionRepo.AddAsync(auction);
        }

        public Task<Auction> GetAsync(Guid id)
        {
            return iAuctionRepo.GetAsync(id);
        }

        public Task<bool> UpdateAsync(Auction auction)
        {
            return iAuctionRepo.UpdateAsync(auction);
        }
    }
}
