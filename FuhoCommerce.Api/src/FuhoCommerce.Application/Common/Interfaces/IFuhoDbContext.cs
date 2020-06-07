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
        DbSet<BuyHistory> BuyHistories { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<FuhoWallet> FuhoWallets { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductOption> ProductOptions { get; set; }
        DbSet<Shipper> Shippers { get; set; }
        DbSet<UserShippingInfo> UserShippingInfos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
