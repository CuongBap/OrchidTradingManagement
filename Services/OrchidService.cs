﻿using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingServices
{
    public class OrchidService : IOrchidService
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();

        public async Task<OrchidProduct> AddAsync(OrchidProduct orchid)
        {
            await orchidTradingManagementContext.OrchidProducts.AddAsync(orchid);
            await orchidTradingManagementContext.SaveChangesAsync();
            return orchid;
        }

        public async Task<OrchidProduct> GetAsync(Guid id)
        {
            var orchid = await orchidTradingManagementContext.OrchidProducts.FirstOrDefaultAsync(x => x.OrchidId == id);
            return orchid;
        }

        public async Task<bool> UpdateAsync(OrchidProduct orchid)
        {
            var existingOrchid = await orchidTradingManagementContext.OrchidProducts.FindAsync(orchid.OrchidId);
            if (existingOrchid != null)
            {
                existingOrchid.OrchidName = orchid.OrchidName;
                existingOrchid.Characteristic = orchid.Characteristic;
                existingOrchid.UnitPrice = orchid.UnitPrice;
                existingOrchid.Quantity = orchid.Quantity;
            }
            var result = await orchidTradingManagementContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }



        public async Task<bool> UpdateAdminAsync(OrchidProduct orchid)
        {
            var existingOrchid = await orchidTradingManagementContext.OrchidProducts.FindAsync(orchid.OrchidId);
            if (existingOrchid != null)
            {
                existingOrchid.OrchidName = orchid.OrchidName;
                existingOrchid.Characteristic = orchid.Characteristic;
                existingOrchid.UnitPrice = orchid.UnitPrice;
                existingOrchid.Quantity = orchid.Quantity;
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