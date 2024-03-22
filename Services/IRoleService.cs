using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingServices
{
    public interface IRoleService
    {
        Task<Guid> GetRoleId(string roleName);
    }
}
