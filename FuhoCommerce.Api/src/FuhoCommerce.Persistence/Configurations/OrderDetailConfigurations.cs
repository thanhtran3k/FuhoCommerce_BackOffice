using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class OrderDetailConfigurations : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.Property(x => x.OrderDetailId)
                .HasColumnName("OrderDetailID")
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithOne(x => x.OrderDetail)
                .HasForeignKey<Order>(x => x.OrderId);

        }
    }
}
