using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.CreateProductOption
{
    public class CreateProductOptionHandler : IRequestHandler<CreateProductOptionCommand>
    {
        public readonly IFuhoDbContext _fuhoDbContext;

        public CreateProductOptionHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<Unit> Handle(CreateProductOptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _fuhoDbContext.ProductOptions.Where(x => x.ProductId == request.ProductId).ToList();

                if (product.Any())
                {
                    var newProductOption = new ProductOption()
                    {
                       ProductId = request.ProductId
                    };

                    _fuhoDbContext.ProductOptions.Add(newProductOption);

                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
