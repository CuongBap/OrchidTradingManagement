using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OrchidTradingRepositories.Models;

public partial class OrchidTradingManagementContext : DbContext
{
    public OrchidTradingManagementContext()
    {
    }

    public OrchidTradingManagementContext(DbContextOptions<OrchidTradingManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Bidding> Biddings { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ListInformation> ListInformations { get; set; }

    public virtual DbSet<OrchidProduct> OrchidProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<RegisterAuction> RegisterAuctions { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        var strConn = config["ConnectionStrings:OrchidManagementDb"];

        return strConn;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.AuctionId).HasName("PK__Auction__51004A4C9E744DD5");

            entity.ToTable("Auction");

            entity.Property(e => e.AuctionId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AuctionName).HasMaxLength(100);
            entity.Property(e => e.CloseDate).HasColumnType("datetime");
            entity.Property(e => e.Deposit).HasColumnType("money");
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.StartingBid)
                .HasColumnType("money")
                .HasColumnName("startingBid");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Bidding>(entity =>
        {
            entity.HasKey(e => e.BidId).HasName("PK__Biddings__4A733D922841BE62");

            entity.Property(e => e.BidId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TotalBid).HasColumnType("money");

            entity.HasOne(d => d.Auction).WithMany(p => p.Biddings)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__Biddings__Auctio__4AB81AF0");

            entity.HasOne(d => d.Register).WithMany(p => p.Biddings)
                .HasForeignKey(d => d.RegisterId)
                .HasConstraintName("FK__Biddings__Regist__4BAC3F29");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Comment__C3B4DFCA98F7EA9E");

            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CommentMessage).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Infor).WithMany(p => p.Comments)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("FK__Comment__InforId__38996AB5");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__UserId__37A5467C");
        });

        modelBuilder.Entity<ListInformation>(entity =>
        {
            entity.HasKey(e => e.InforId).HasName("PK__ListInfo__1D605C530ECB101D");

            entity.ToTable("ListInformation");

            entity.Property(e => e.InforId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Auction).WithMany(p => p.ListInformations)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__ListInfor__Aucti__32E0915F");

            entity.HasOne(d => d.Orchid).WithMany(p => p.ListInformations)
                .HasForeignKey(d => d.OrchidId)
                .HasConstraintName("FK__ListInfor__Orchi__31EC6D26");

            entity.HasOne(d => d.User).WithMany(p => p.ListInformations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ListInfor__UserI__33D4B598");
        });

        modelBuilder.Entity<OrchidProduct>(entity =>
        {
            entity.HasKey(e => e.OrchidId).HasName("PK__OrchidPr__9153F8745D2D0919");

            entity.ToTable("OrchidProduct");

            entity.Property(e => e.OrchidId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Characteristic).HasMaxLength(100);
            entity.Property(e => e.OrchidName).HasMaxLength(100);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFAF318EA7");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Auction).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK__Order__AuctionId__3E52440B");

            entity.HasOne(d => d.Buyer).WithMany(p => p.OrderBuyers)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK__Order__BuyerId__3C69FB99");

            entity.HasOne(d => d.Seller).WithMany(p => p.OrderSellers)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__Order__SellerId__3D5E1FD2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C5CA3B1F6");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Orchid).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrchidId)
                .HasConstraintName("FK__OrderDeta__Orchi__4222D4EF");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__4316F928");
        });

        modelBuilder.Entity<RegisterAuction>(entity =>
        {
            entity.HasKey(e => e.RegisterId).HasName("PK__Register__B91FAB79C663BD3B");

            entity.ToTable("RegisterAuction");

            entity.Property(e => e.RegisterId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.User).WithMany(p => p.RegisterAuctions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RegisterA__UserI__46E78A0C");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6B87414C6D");

            entity.ToTable("Transaction");

            entity.Property(e => e.TransactionId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Order).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Order__4F7CD00D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C968123C2");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.WalletBalance).HasColumnType("money");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__2B3F6F97");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE1A22E66059");

            entity.ToTable("UserRole");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
