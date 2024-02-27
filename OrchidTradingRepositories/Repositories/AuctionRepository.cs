using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();
        public async Task<Auction> AddAsync(Auction auction)
        {
           await orchidTradingManagementContext.Auctions.AddAsync(auction);
            await orchidTradingManagementContext.SaveChangesAsync();
            return auction;
        }

        public async Task<Auction> GetAsync(Guid id)
        {
            var auction = await orchidTradingManagementContext.Auctions.FirstOrDefaultAsync(x => x.AuctionId == id);
            return auction;
        }

        public async Task<bool> UpdateAsync(Auction auction)
        {
            throw new NotImplementedException();
        }
    }
}
