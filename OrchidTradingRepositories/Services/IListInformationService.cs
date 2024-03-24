using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public interface IListInformationService
    {
        Task<IEnumerable<ListInformation>> GetAllAsync();
        Task<ListInformation> GetAsync(Guid id);
        Task<IEnumerable<SellOrchidDTO>> GetAllMySellListInformationAsync(string id);
        Task<IEnumerable<SellOrchidDTO>> GetAllSellListInformationAsync();
        Task<IEnumerable<AuctionOrchidDTO>> GetAllAuctionListInformationAsync();
        Task<IEnumerable<AuctionOrchidDTO>> GetAllMyAuctionListInformationAsync(string id);
        Task<IEnumerable<ListInformation>> SearchListInformationAsync(string searchValue);
        Task<bool> UpdateAsync(ListInformation listInformation);
        Task<bool> UpdateAdminAsync(ListInformation listInformation);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> AddAsync(string id, AddOrchid orchid, AddListInformation listInformation, AddAuction addAuctionRequest);
    }
}
