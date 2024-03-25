using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class Register
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
        public decimal? WalletBalance { get; set; }
        [Required]
        [MinLength(10)]
        public string Phonenumber { get; set; } = null!;
        public string Status { get; set; } = null!;

        public Guid RoleId { get; set; }
    }
}
