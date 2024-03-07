using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();

        public async Task<Guid> GetRoleId(string roleName)
        {
            var id = await orchidTradingManagementContext.UserRoles.Where(x => x.RoleName.Equals(roleName)).Select(x => x.RoleId).FirstOrDefaultAsync();  
               return id;
        }
    }
}
