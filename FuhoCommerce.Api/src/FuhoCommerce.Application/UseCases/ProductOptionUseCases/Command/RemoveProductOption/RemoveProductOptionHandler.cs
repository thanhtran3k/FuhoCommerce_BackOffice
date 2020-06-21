using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.RemoveProductOption
{
    public class RemoveProductOptionHandler : IRequestHandler<RemoveProductOptionCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public RemoveProductOptionHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<Unit> Handle(RemoveProductOptionCommand request, CancellationToken cancellationToken)
        {
            var result = await _fuhoDbContext.ProductOptions.FindAsync(request.ProductOptionId);

            if (result != null)
            {
                _fuhoDbContext.ProductOptions.Remove(result);
                await _fuhoDbContext.SaveChangesAsync(cancellationToken);
            } else
            {
                throw new NullResult(nameof(ProductOption), nameof(request.ProductOptionId));
            }

            return Unit.Value;
        }
    }
}
