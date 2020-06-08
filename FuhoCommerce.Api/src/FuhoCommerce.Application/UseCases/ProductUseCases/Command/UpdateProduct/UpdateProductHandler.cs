using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<UpdateProductHandler> _logger;

        public UpdateProductHandler(IFuhoDbContext fuhoDbContext, ILogger<UpdateProductHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _fuhoDbContext.Products.FindAsync(request.ProductId);

                if (product != null)
                {
                    //Save product
                    product.ProductName = request.ProductName;
                    product.BrandName = request.BrandName;
                    product.Price = request.Price;
                    product.Sku = request.Sku;
                    product.Stock = request.Stock;
                    product.CategoryId = request.CategoryId;
                    product.ProductOptions = request.ProductOptions;

                    _fuhoDbContext.Products.Update(product);
                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                else
                {
                    throw new NullResult(nameof(Product), nameof(request.ProductId));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}