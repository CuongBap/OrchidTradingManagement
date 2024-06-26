﻿using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public interface IListInformationRepository
    {
        Task<IEnumerable<ListInformation>> GetAllAsync();
        Task<ListInformation> GetAsync(Guid id);
        Task<ListInformation> AddAsync(ListInformation listInformation);
        Task<bool> UpdateAsync(ListInformation listInformation);
        Task<bool> DeleteAsync(Guid id);

        Task<bool> AddAsync(string id , AddOrchid orchid, AddListInformation listInformation, AddAuction addAuctionRequest);

    }
}
