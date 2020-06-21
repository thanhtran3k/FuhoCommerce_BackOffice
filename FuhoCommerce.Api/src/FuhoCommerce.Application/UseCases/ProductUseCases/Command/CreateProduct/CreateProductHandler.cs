using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly IFileSystemService _fileSystemService;

        public CreateProductHandler(IFuhoDbContext fuhoDbContext, IFileSystemService fileSystemService)
        {
            _fuhoDbContext = fuhoDbContext;
            _fileSystemService = fileSystemService;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newProduct = new Product()
                {
                    ProductName = request.ProductName,
                    BrandName = request.BrandName,
                    Price = request.Price,
                    Sku = request.Sku,
                    Stock = request.Stock,
                    ProductOptions = request.ProductOptions,
                    Images = await _fileSystemService.SingleUpload(request.File),
                    CategoryId = request.CategoryId
                };

                _fuhoDbContext.Products.Add(newProduct);

                await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
