using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.Name)
                .HasColumnType("nvarchar(30)")
                .IsRequired()
                .HasMaxLength(15);

            builder.HasMany(r => r.Products);
        }
    }
}
