using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models.Enums;

namespace OrchidTradingRepositories.Repositories
{
    public class ListInformationRepository : IListInformationRepository
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();
        public async Task<bool> AddAsync(string id, AddOrchid orchid, AddListInformation listInformation, AddAuction auction)
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
                        CreatedDate = DateTime.Now,
                        Status = ListInformationStatus.Processing.ToString(),
                        OrchidId = orchidId,
                        UserId = Guid.Parse(id)

                    }) ;
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
                        CreatedDate = DateTime.Now,
                        Status = ListInformationStatus.Processing.ToString(),
                        AuctionId = auctionId,
                        UserId = Guid.Parse(id)
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
            var existingOrchid = await orchidTradingManagementContext.ListInformations.FindAsync(id);
            if(existingOrchid != null)
            {
                existingOrchid.Status = ListInformationStatus.Unavailable.ToString();
            }
            await orchidTradingManagementContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ListInformation>> GetAllAsync()
        {
            return await orchidTradingManagementContext.ListInformations.ToListAsync();
        }

        public async Task<IEnumerable<SellOrchidDTO>> GetAllMySellListInformationAsync(string id)
        {
            var result = await orchidTradingManagementContext.ListInformations.Include(x => x.Orchid).Where(x => x.UserId != null && x.UserId == Guid.Parse(id) && !x.Status.Equals(ListInformationStatus.Unavailable.ToString()) && x.OrchidId != null).Select(x => new SellOrchidDTO
            {
               InforId = x.InforId,
               Title = x.Title,
               Description = x.Description,
               Image = x.Image,
               CreatedDate = x.CreatedDate,
               Status = x.Status,
               UserId = x.UserId,
               OrchidId = x.OrchidId,
               OrchidName = x.Orchid.OrchidName,
               Characteristic = x.Orchid.Characteristic,
               UnitPrice = x.Orchid.UnitPrice,
               Quantity = x.Orchid.Quantity
            }).OrderByDescending(x => x.Quantity).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<SellOrchidDTO>> GetAllSellListInformationAsync()
        {
            var infors = await orchidTradingManagementContext.ListInformations
                         .Where(x => x.Status == ListInformationStatus.Approved.ToString() && x.OrchidId != null)
                         .Include(x => x.Orchid)
                         .ToListAsync();

            var result = infors
                .Select(async x => new SellOrchidDTO
            {
                InforId = x.InforId,
                Title = x.Title,
                Description = x.Description,
                Image = x.Image,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                UserId = x.UserId,
                OrchidId = x.OrchidId,
                OrchidName = x.Orchid.OrchidName,
                Characteristic = x.Orchid.Characteristic,
                UnitPrice = x.Orchid.UnitPrice,
                Quantity = x.Orchid.Quantity
            }).Select(x => x.Result)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

            return result;
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


        public async Task<bool> UpdateAdminAsync(ListInformation listInformation)
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

        public async Task<IEnumerable<AuctionOrchidDTO>> GetAllAuctionListInformationAsync()
        {
            var infors = await orchidTradingManagementContext.ListInformations
                         .Where(x => x.Status == ListInformationStatus.Approved.ToString() && x.AuctionId != null)
                         .Include(x => x.Auction)
                         .ToListAsync();

            var result = infors
                .Select(async x => new AuctionOrchidDTO
                {
                    InforId = x.InforId,
                    Title = x.Title,
                    Description = x.Description,
                    Image = x.Image,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status,
                    UserId = x.UserId,
                    AuctionId = x.AuctionId,
                    AuctionName = x.Auction.AuctionName,
                    Deposit = x.Auction.Deposit,
                    StartingBid = x.Auction.StartingBid,
                    OpenDate = x.Auction.OpenDate,
                    CloseDate = x.Auction.CloseDate,
                }).Select(x => x.Result)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

            return result;
        }
    }
}
