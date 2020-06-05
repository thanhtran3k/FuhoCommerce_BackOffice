using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.CrossCuttingConcern;
using FuhoCommerce.Domain.Common;
using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Persistence.EFDbContext
{
    public class FuhoDbContext : DbContext, IFuhoDbContext
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly ICurrentUserService _currentUserService;

        public FuhoDbContext(DbContextOptions<FuhoDbContext> options) : base(options)
        {
        }

        public FuhoDbContext(DbContextOptions<FuhoDbContext> options, 
            IDateTimeProvider dateTimeProvider,
            ICurrentUserService currentUserService) : base(options)
        {
            _dateTimeProvider = dateTimeProvider;
            _currentUserService = currentUserService;
        }

        #region DbSetFields here

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<BuyerCart> BuyerCarts { get; set; }
        public DbSet<BuyerComment> BuyerComments { get; set; }
        public DbSet<BuyerHistory> BuyerHistories { get; set; }
        public DbSet<BuyerShippingInfo> BuyerShippingInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FuhoWallet> FuhoWallets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierCategory> SupplierCategories { get; set; }

        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = _dateTimeProvider.UtcNow;
                        entry.Entity.CreatedBy = _currentUserService.UserId ?? "system";
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateDate = _dateTimeProvider.UtcNow;
                        entry.Entity.UpdatedBy = _currentUserService.UserId ?? "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuhoDbContext).Assembly);
        }
    }
}
