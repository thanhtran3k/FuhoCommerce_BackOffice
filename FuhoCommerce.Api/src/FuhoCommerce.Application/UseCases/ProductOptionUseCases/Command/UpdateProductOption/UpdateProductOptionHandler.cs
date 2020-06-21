using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.UpdateProductOption
{
    public class UpdateProductOptionHandler : IRequestHandler<UpdateProductOptionCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<UpdateProductOptionHandler> _logger;

        public UpdateProductOptionHandler(IFuhoDbContext fuhoDbContext, ILogger<UpdateProductOptionHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _fuhoDbContext.ProductOptions.FindAsync(request.ProductOptionId);

                if (comment != null)
                {
                    //Save category
                    

                    _fuhoDbContext.ProductOptions.Update(comment);
                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                else
                {
                    throw new NullResult(nameof(ProductOption), nameof(request.ProductOptionId));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}