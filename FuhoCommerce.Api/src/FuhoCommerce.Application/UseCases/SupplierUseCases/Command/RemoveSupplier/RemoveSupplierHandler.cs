using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Command.RemoveSupplier
{
    public class RemoveSupplierHandler : IRequestHandler<RemoveSupplierCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public RemoveSupplierHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<Unit> Handle(RemoveSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await _fuhoDbContext.Suppliers.FindAsync(request.SupplierId);

            if (result != null)
            {
                _fuhoDbContext.Suppliers.Remove(result);
                await _fuhoDbContext.SaveChangesAsync(cancellationToken);
            } else
            {
                throw new NullResult(nameof(Supplier), nameof(request.SupplierId));
            }

            return Unit.Value;
        }
    }
}
