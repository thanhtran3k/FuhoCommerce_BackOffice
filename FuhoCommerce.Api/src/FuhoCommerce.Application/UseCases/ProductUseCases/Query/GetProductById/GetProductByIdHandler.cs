using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetProductByIdHandler> _logger;

        public GetProductByIdHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByIdhandler - Get product by id");

            var result = await _fuhoDbContext.Products
                .AsNoTracking()
                .Where(x => x.ProductId == request.ProductId)
                .Select(x => new ProductDto
                {
                    ProductId = x.ProductId,
                    BrandName = x.BrandName,
                    ProductName = x.ProductName,
                    Price = x.Price, 
                    Sku = x.Sku,
                    Stock = x.Stock
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return result;
        }
    }
}