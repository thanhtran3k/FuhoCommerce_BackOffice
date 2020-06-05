using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class BuyerConfigurations : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(15);
            builder.Property(p => p.LastName).HasMaxLength(15);

            builder.HasMany(r => r.BuyerHistories);

            builder.HasMany(r => r.BuyerShippingInfos);

            builder.HasMany(r => r.Orders);
        }
    }
}
