using FuhoCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuhoCommerce.Persistence.Configurations
{
    public class BuyerCartConfigurations : IEntityTypeConfiguration<BuyerCart>
    {
        public void Configure(EntityTypeBuilder<BuyerCart> builder)
        {
            builder.HasOne(r => r.Buyer)
                .WithOne(r => r.BuyerCart);
        }
    }
}
