using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FuhoCommerce.Persistence.Configurations
{
    public class BuyerCommentConfigurations : IEntityTypeConfiguration<BuyerComment>
    {
        public void Configure(EntityTypeBuilder<BuyerComment> builder)
        {
            builder.HasOne(r => r.Product)
                .WithMany(r => r.BuyerComments)
                .HasForeignKey(k => k.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
