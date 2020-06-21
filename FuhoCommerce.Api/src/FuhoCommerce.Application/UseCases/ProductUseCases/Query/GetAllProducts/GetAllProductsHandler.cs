using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductsUseCases.Query.GetAllProductss
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, ProductListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllProductsHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<ProductListVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productList = await _fuhoDbContext.Products
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .OrderByDescending(x => x.CreateDate)
                .Select(x => new ProductDto
                {
                    ProductId = x.ProductId,
                    BrandName = x.BrandName,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    Sku = x.Sku,
                    Stock = x.Stock
                })
                .ToListAsync();

            var productListVm = new ProductListVm
            {
                ProductDtos = productList
            };

            return productListVm;
        }
    }
}
