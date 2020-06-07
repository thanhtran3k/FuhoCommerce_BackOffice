using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SeedWork
{
    public class SeedData
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        private readonly Dictionary<int, Category> Categories = new Dictionary<int, Category>();

        public SeedData(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task CentrializedSeeding(CancellationToken cancellationToken)
        {
            await SeedCategories(cancellationToken);
        }

        private async Task SeedCategories(CancellationToken cancellationToken)
        {
            Categories.Add(1, new Category { CategoryId = Guid.NewGuid(), Name = "Men's Fashion", Thumbnail = "no-image.jpg" });
            Categories.Add(2, new Category { CategoryId = Guid.NewGuid(), Name = "Women's Fashion", Thumbnail = "no-image.jpg" });
            Categories.Add(3, new Category { CategoryId = Guid.NewGuid(), Name = "Home & Kitchen", Thumbnail = "no-image.jpg" });
            Categories.Add(4, new Category { CategoryId = Guid.NewGuid(), Name = "Computers", Thumbnail = "no-image.jpg" });
            Categories.Add(5, new Category { CategoryId = Guid.NewGuid(), Name = "Electronics", Thumbnail = "no-image.jpg" });
            Categories.Add(6, new Category { CategoryId = Guid.NewGuid(), Name = "Toys & Games", Thumbnail = "no-image.jpg" });
            Categories.Add(7, new Category { CategoryId = Guid.NewGuid(), Name = "Video Games", Thumbnail = "no-image.jpg" });

            foreach (var category in Categories.Values)
            {
                _fuhoDbContext.Categories.Add(category);
            }

            await _fuhoDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
