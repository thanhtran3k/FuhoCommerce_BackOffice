using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class ProductOptionConfigurations : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.Property(x => x.ProductOptionId)
                .HasColumnName("ProductOptionID")
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductOptions)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
