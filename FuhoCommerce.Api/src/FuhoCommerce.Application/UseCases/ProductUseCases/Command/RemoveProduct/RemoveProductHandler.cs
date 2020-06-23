using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct
{
    public class RemoveProductHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public RemoveProductHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }
        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _fuhoDbContext.Products.FindAsync(request.ProductId);

            if (request.UserId != result.CreatedBy) throw new ForbiddenAction(nameof(RemoveProductHandler), request.UserId);

            if (result == null) throw new NullResult(nameof(Product), nameof(request.ProductId));

            _fuhoDbContext.Products.Remove(result);
            await _fuhoDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
