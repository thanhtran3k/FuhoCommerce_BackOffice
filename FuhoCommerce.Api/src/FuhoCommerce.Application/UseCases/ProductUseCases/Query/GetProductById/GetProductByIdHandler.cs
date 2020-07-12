using System.Threading;
using System.Threading.Tasks;
using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDetailVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetProductByIdHandler> _logger;

        public GetProductByIdHandler(IFuhoDbContext fuhoDbContext, ILogger<GetProductByIdHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<ProductDetailVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByIdhandler - Get product by id");

            var product = await _fuhoDbContext.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ProductId == request.ProductId);

            if (product == null) throw new NullResult(nameof(Product), request.ProductId);

            var productDetail = new ProductDetailVm
            {
                ProductId = product.ProductId,
                CaterogyId = product.CategoryId,
                CategoryName = product.Category.Name,
                BrandName = product.BrandName,
                Price = product.Price,
                ProductName = product.ProductName,
                Sku = product.Sku,
                Stock = product.Stock,
                ProductOptions = product.ProductOptions
            };

            return productDetail;
        }
    }
}