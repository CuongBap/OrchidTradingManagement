using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class ListInformationService : IListInformationService
    {
        private readonly IListInformationRepository iListInformationRepository = null;

        public ListInformationService()
        {
            iListInformationRepository = new ListInformationRepository();
        }

        public Task<bool> AddAsync(string id, AddOrchid orchid, AddListInformation listInformation, AddAuction addAuctionRequest)
        {
            return iListInformationRepository.AddAsync(id, orchid, listInformation, addAuctionRequest);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return iListInformationRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<ListInformation>> GetAllAsync()
        {
            return iListInformationRepository.GetAllAsync();
        }

        public Task<IEnumerable<AuctionOrchidDTO>> GetAllAuctionListInformationAsync()
        {
           return iListInformationRepository.GetAllAuctionListInformationAsync();
        }

        public Task<IEnumerable<AuctionOrchidDTO>> GetAllMyAuctionListInformationAsync(string id)
        {
            return iListInformationRepository.GetAllMyAuctionListInformationAsync(id);
        }

        public Task<IEnumerable<SellOrchidDTO>> GetAllMySellListInformationAsync(string id)
        {
            return iListInformationRepository.GetAllMySellListInformationAsync(id);
        }

        public Task<IEnumerable<SellOrchidDTO>> GetAllSellListInformationAsync()
        {
            return iListInformationRepository.GetAllSellListInformationAsync();
        }

        public Task<ListInformation> GetAsync(Guid id)
        {
            return iListInformationRepository.GetAsync(id);
        }

        public Task<IEnumerable<ListInformation>> SearchListInformationAsync(string searchValue)
        {
            return iListInformationRepository.SearchListInformationAsync(searchValue);
        }

        public Task<bool> UpdateAdminAsync(ListInformation listInformation)
        {
            return iListInformationRepository.UpdateAdminAsync(listInformation);
        }

        public Task<bool> UpdateAsync(ListInformation listInformation)
        {
            return iListInformationRepository.UpdateAsync(listInformation);
        }
    }
}
