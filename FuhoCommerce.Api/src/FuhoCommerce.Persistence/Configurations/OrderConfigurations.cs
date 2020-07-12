using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.OrderId).HasColumnName("OrderID")
                .IsRequired();

            builder.HasOne(x => x.Shipper)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.OrderId);

            builder.HasOne(x => x.OrderDetail)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.OrderId);
        }
    }
}
