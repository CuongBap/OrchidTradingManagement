using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrchidTradingRepositories.Repositories
{
    public class ListInformationRepository : IListInformationRepository
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();


        public async Task<ListInformation> AddAsync(ListInformation listInformation)
        {
            await orchidTradingManagementContext.ListInformations.AddAsync(listInformation);
            await orchidTradingManagementContext.SaveChangesAsync();
            return listInformation;
        }

        public async Task<bool> AddAsync(AddOrchid orchid, AddListInformation listInformation, AddAuction auction)
        {
            if (orchid != null)
            {
                var orchidModel = new OrchidProduct
                {
                    OrchidId = Guid.NewGuid(),
                    OrchidName = orchid.OrchidName,
                    Characteristic = orchid.Characteristic,
                    UnitPrice = orchid.UnitPrice,
                    Quantity = orchid.Quantity,
                    Status = orchid.Status,

                };
                await orchidTradingManagementContext.OrchidProducts.AddAsync(orchidModel);
                var rs1 = await orchidTradingManagementContext.SaveChangesAsync();
                if (rs1 > 0)
                {
                    var orchidId = orchidModel.OrchidId;
                    await orchidTradingManagementContext.ListInformations.AddAsync(new ListInformation
                    {
                        InforId = Guid.NewGuid(),
                        Title = listInformation.Title,
                        Description = listInformation.Description,
                        Image = listInformation.Image,
                        CreatedDate = listInformation.CreatedDate,
                        Status = listInformation.Status,
                        OrchidId = orchidId,

                    });
                    var check1 = await orchidTradingManagementContext.SaveChangesAsync();
                    if (check1 > 0)
                        return true;
                }
                return false;
            }
            if(auction != null)
            {
                var auctionModel = new Auction
                {
                    AuctionId = Guid.NewGuid(),
                    AuctionName = auction.AuctionName,
                    Deposit = auction.Deposit,
                    StartingBid = auction.StartingBid,
                    OpenDate = auction.OpenDate,
                    CloseDate = auction.CloseDate,
                    Status = auction.Status,
                };
                await orchidTradingManagementContext.Auctions.AddAsync(auctionModel);
                var rs2 = await orchidTradingManagementContext.SaveChangesAsync();
                if(rs2 > 0)
                {
                    var auctionId = auctionModel.AuctionId;
                    await orchidTradingManagementContext.ListInformations.AddAsync(new ListInformation
                    {
                        InforId = Guid.NewGuid(),
                        Title = listInformation.Title,
                        Description = listInformation.Description,
                        Image = listInformation.Image,
                        CreatedDate = listInformation.CreatedDate,
                        Status = listInformation.Status,
                        AuctionId = auctionId,
                    });
                    var check2 = await orchidTradingManagementContext.SaveChangesAsync();
                    if(check2 > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ListInformation>> GetAllAsync()
        {
            return await orchidTradingManagementContext.ListInformations.ToListAsync();
        }

        public async Task<ListInformation> GetAsync(Guid id)
        {
            return await orchidTradingManagementContext.ListInformations.Where(x => x.InforId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(ListInformation listInformation)
        {
            var existingListinfo = await orchidTradingManagementContext.ListInformations.FindAsync(listInformation.InforId);
            if (existingListinfo != null)
            {
                existingListinfo.Title = listInformation.Title;
                existingListinfo.Description = listInformation.Description;
                existingListinfo.Image = listInformation.Image;
                existingListinfo.CreatedDate = listInformation.CreatedDate;
                existingListinfo.Status = listInformation.Status;
                var result = await orchidTradingManagementContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
