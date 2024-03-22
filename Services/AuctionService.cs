using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingServices
{
    public class AuctionService : IAuctionService
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
            return await orchidTradingManagementContext.Auctions.FirstOrDefaultAsync(c => c.AuctionId == id);
        }

        public async Task<bool> UpdateAsync(Auction auction)
        {
            var existingAuction = await orchidTradingManagementContext.Auctions.FindAsync(auction.AuctionId);
            if (existingAuction != null)
            {
                existingAuction.AuctionName = auction.AuctionName;
                existingAuction.Deposit = auction.Deposit;
                existingAuction.StartingBid = auction.StartingBid;
                existingAuction.OpenDate = auction.OpenDate;
                existingAuction.CloseDate = auction.CloseDate;
            }
            var result = await orchidTradingManagementContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
