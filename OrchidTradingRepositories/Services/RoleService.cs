using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _iRoleRepository = null;

        public RoleService()
        {
            _iRoleRepository = new RoleRepository();
        }

        public Task<Guid> GetRoleId(string roleName)
        {
            return _iRoleRepository.GetRoleId(roleName);
        }
    }
}
