using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public interface IUserService
    {
        Task<User> GetAsync(Guid id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Guid id);
        Task<User> LoginAsync(string username, string password);
    }
}
