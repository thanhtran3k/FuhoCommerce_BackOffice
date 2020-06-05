using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FuhoCommerce.Persistence.Configurations
{
    public class FuhoWalletConfigurations : IEntityTypeConfiguration<FuhoWallet>
    {
        public void Configure(EntityTypeBuilder<FuhoWallet> builder)
        {
            builder.Property(p => p.FuhoCoin).HasColumnType("money");
            builder.Property(p => p.FuhoMoney).HasColumnType("money");

            builder.HasOne(r => r.Buyer);
        }
    }
}
