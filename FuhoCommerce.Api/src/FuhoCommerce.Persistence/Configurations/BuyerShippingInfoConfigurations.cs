using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class BuyerShippingInfoConfigurations : IEntityTypeConfiguration<BuyerShippingInfo>
    {
        public void Configure(EntityTypeBuilder<BuyerShippingInfo> builder)
        {
            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.StreetName)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.Ward)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.District)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.City)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.Country)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.ShippingAddress)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(r => r.Buyer)
                .WithMany(r => r.BuyerShippingInfos)
                .HasForeignKey(k => k.BuyerId);
        }
    }
}
