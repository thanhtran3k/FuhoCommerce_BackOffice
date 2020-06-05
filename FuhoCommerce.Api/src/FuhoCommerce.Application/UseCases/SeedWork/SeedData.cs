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
        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();
        private readonly Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
        private readonly Dictionary<int, FuhoWallet> FuhoWallets = new Dictionary<int, FuhoWallet>();

        public SeedData(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task CentrializedSeeding()
        {

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

        private async Task SeedFuhoWallet(CancellationToken cancellationToken)
        {
            FuhoWallets.Add(1, new FuhoWallet { FuhoWalletId = Guid.NewGuid(), FuhoCoin = 3000, FuhoMoney = 3000, FuhoCoinExpiryDate = DateTime.UtcNow.AddDays(5) });
            FuhoWallets.Add(2, new FuhoWallet { FuhoWalletId = Guid.NewGuid(), FuhoCoin = 3000, FuhoMoney = 3000, FuhoCoinExpiryDate = DateTime.UtcNow.AddDays(5) });

            foreach (var fuhoWallet in FuhoWallets.Values)
            {
                _fuhoDbContext.FuhoWallets.Add(fuhoWallet);
            }

            await _fuhoDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedProducts(CancellationToken cancellationToken)
        {
            Products.Add(1, new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = "iPineapple Z",
                BrandName = "Pineapple",
                Sku = "PinZBB6D",
                Price = 1200,
                Stock = 15,
                CategoryId = Categories[5].CategoryId,
                Category = Categories[5],
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        Optionkey = "Color",
                        OptionValues = "Black, Red"
                    }
                }
            });

            Products.Add(2, new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = "iPineapple 11+1",
                BrandName = "Pineapple",
                Sku = "PinZBB6D",
                Price = 990,
                Stock = 15,
                CategoryId = Categories[5].CategoryId,
                Category = Categories[5],
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        Optionkey = "Color",
                        OptionValues = "Black, Red"
                    },
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        Optionkey = "Capacity",
                        OptionValues = "64GB, 128GB"
                    },
                }
            });

            Products.Add(3, new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Gu Chì Purse",
                BrandName = "Gu Chì",
                Sku = "GU123",
                Price = 1990,
                Stock = 25,
                CategoryId = Categories[1].CategoryId,
                Category = Categories[1],
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        Optionkey = "Color",
                        OptionValues = "Black, Red"
                    }
                }
            });

            Products.Add(4, new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = "Vờ Sa Chì Bag",
                BrandName = "Vờ Sa Chì",
                Sku = "VER123",
                Price = 1990,
                Stock = 25,
                CategoryId = Categories[2].CategoryId,
                Category = Categories[2],
                ProductOptions = new List<ProductOption>
                {
                    new ProductOption
                    {
                        ProductOptionId = Guid.NewGuid(),
                        Optionkey = "Color",
                        OptionValues = "Black, Red"
                    }
                }
            });

            foreach (var product in Products.Values)
            {
                _fuhoDbContext.Products.Add(product);
            }

            await _fuhoDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedSupplier(CancellationToken cancellationToken)
        {
            Suppliers.Add(1, new Supplier
            {
                SupplierId = Guid.NewGuid(),
                Name = "Pineapple Inc.",
                Address = "Ap Bac Valley, HCMC",
                Description = @"Pineapple Inc. là một tập đoàn công nghệ của Mỹ Tho có trụ sở chính đặt tại Ap Bac, HCM. Pineapple được thành lập ngày 1 tháng 4 năm 1976 dưới tên Pineapple Computer, Inc., và đổi tên thành Pineapple Inc. vào đầu năm 2007.",
                PhoneNumber = "090000000",
                Products = new List<Product>() { Products[1], Products[2] },
                SupplierCategories = new List<SupplierCategory>()
                {
                    new SupplierCategory 
                    { 
                        SupplierCategoryName = "Custom Supplier Category", 
                        Products = new List<Product>() { Products[1] }
                    }
                }
            });

            Suppliers.Add(2, new Supplier
            {
                SupplierId = Guid.NewGuid(),
                Name = "Gu Chì",
                Address = "Ý Ta Lì, HCMC",
                Description = @"Looking at my Gu chì, it's about the time",
                PhoneNumber = "090000001",
                Products = new List<Product>() { Products[3] }
            });

            Suppliers.Add(3, new Supplier
            {
                SupplierId = Guid.NewGuid(),
                Name = "Vờ Sa Chì",
                Address = "Italia, Italia",
                Description = @"Looking at my Vờ Sa Chì, it's about the time",
                PhoneNumber = "090000002",
                Products = new List<Product>() { Products[4] }
            });

            foreach (var supplier in Suppliers.Values)
            {
                _fuhoDbContext.Suppliers.Add(supplier);
            }

            await _fuhoDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
