using Microsoft.EntityFrameworkCore;
using OrchidTradingRepositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OrchidTradingManagementContext orchidTradingManagementContext = new();
        public async Task<User> AddAsync(User user)
        {
            var check = await orchidTradingManagementContext.Users.Where(x => x.Username == user.Username).FirstOrDefaultAsync();
            if (check == null)
            {
                await orchidTradingManagementContext.Users.AddAsync(user);
                await orchidTradingManagementContext.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await orchidTradingManagementContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
