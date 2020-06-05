using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        public readonly IFuhoDbContext _fuhoDbContext;

        public CreateProductHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
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
                    CategoryId = request.CategoryId,
                    SupplierId = request.SupplierId,
                    ProductOptions = request.ProductOptions
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
