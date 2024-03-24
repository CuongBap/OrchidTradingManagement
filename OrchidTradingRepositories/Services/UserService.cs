using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository = null;

        public UserService()
        {
            _iUserRepository = new UserRepository();
        }

        public Task<User> AddAsync(User user)
        {
            return _iUserRepository.AddAsync(user);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _iUserRepository.DeleteAsync(id);
        }

        public Task<User> GetAsync(Guid id)
        {
            return _iUserRepository.GetAsync(id);
        }

        public Task<User> LoginAsync(string username, string password)
        {
            return _iUserRepository.LoginAsync(username,password);
        }

        public Task<User> UpdateAsync(User user)
        {
            return _iUserRepository.UpdateAsync(user);
        }
    }
}
