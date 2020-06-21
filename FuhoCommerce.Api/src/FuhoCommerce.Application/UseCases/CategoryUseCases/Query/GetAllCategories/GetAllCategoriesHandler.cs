using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllCategoriesHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<CategoryListVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var productList = await _fuhoDbContext.Categories
                .OrderByDescending(x => x.Name)
                .Include(x => x.Products)
                .Select(x => new CategoryDto
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Thumbnail = x.Thumbnail,
                    Products = x.Products
                    .Select(y => new ProductDto 
                    {
                        ProductId = y.ProductId,
                        ProductName = y.ProductName,
                        BrandName = y.BrandName,
                        Price = y.Price,
                        Sku = y.Sku,
                        Stock = y.Stock
                    }).ToList()
                })
                .ToListAsync();

            var productListVm = new CategoryListVm
            {
                CategoryDtos = productList
            };

            return productListVm;
        }
    }
}
