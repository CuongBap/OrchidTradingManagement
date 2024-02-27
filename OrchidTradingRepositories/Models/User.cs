using System;
using System.Collections.Generic;

namespace OrchidTradingRepositories.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal? WalletBalance { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ListInformation> ListInformations { get; set; } = new List<ListInformation>();

    public virtual ICollection<Order> OrderBuyers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSellers { get; set; } = new List<Order>();

    public virtual ICollection<RegisterAuction> RegisterAuctions { get; set; } = new List<RegisterAuction>();

    public virtual UserRole Role { get; set; } = null!;
}
