using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetProductByIdHandler> _logger;

        public GetProductByIdHandler(IFuhoDbContext fuhoDbContext, ILogger<GetProductByIdHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductByIdhandler - Get product by id");

            var result = await _fuhoDbContext.Products
                .AsNoTracking()
                .Include(x => x.ProductOptions)
                .Select(x => new ProductDto
                {
                    ProductId = x.ProductId,
                    BrandName = x.BrandName,
                    Price = x.Price,
                    ProductName = x.ProductName,
                    Sku = x.Sku,
                    Stock = x.Stock,
                    ProductOption = x.ProductOptions
                    .Select(y => new ProductOptionDto
                    {
                        Optionkey = y.Optionkey,
                        OptionValues = y.OptionValues,
                        ProductOptionId = y.ProductOptionId
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return result;
        }
    }
}