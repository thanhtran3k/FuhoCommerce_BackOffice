using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly IFileSystemService _fileSystemService;
        private readonly ILogger<UpdateProductHandler> _logger;

        public UpdateProductHandler(IFuhoDbContext fuhoDbContext, IFileSystemService fileSystemService, ILogger<UpdateProductHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _fileSystemService = fileSystemService;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _fuhoDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == request.ProductId);

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
                    product.Images = await _fileSystemService.SingleUpdate(request.file, product.Images);

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