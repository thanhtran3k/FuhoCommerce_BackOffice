using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.Common.Interfaces
{
    public interface IFuhoDbContext
    {
        DbSet<Buyer> Buyers { get; set; }
        DbSet<BuyerCart> BuyerCarts { get; set; }
        DbSet<BuyerComment> BuyerComments { get; set; }
        DbSet<BuyerHistory> BuyerHistories { get; set; }
        DbSet<BuyerShippingInfo> BuyerShippingInfos { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<FuhoWallet> FuhoWallets { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductOption> ProductOptions { get; set; }
        DbSet<Shipper> Shippers { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<SupplierCategory> SupplierCategories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
