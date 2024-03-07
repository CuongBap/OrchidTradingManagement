using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class Register
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public decimal? WalletBalance { get; set; }

        public string Phonenumber { get; set; } = null!;

        public string Status { get; set; } = null!;

        public Guid RoleId { get; set; }
    }
}
