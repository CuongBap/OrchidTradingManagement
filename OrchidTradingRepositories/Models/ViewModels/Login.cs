using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchidTradingRepositories.Models.ViewModels
{
    public class Login
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
