using FuhoCommerce.Application.Common.Exceptions;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Command.UpdateSupplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierCommand>
    {    
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<UpdateSupplierHandler> _logger;

        public UpdateSupplierHandler(IFuhoDbContext fuhoDbContext, ILogger<UpdateSupplierHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var suppplier = await _fuhoDbContext.Suppliers.FindAsync(request.SupplierId);

                if (suppplier != null)
                {
                    //Save supplier
                    suppplier.Name = request.Name;
                    suppplier.Email = request.Email;
                    suppplier.Address = request.Address;
                    suppplier.Description = request.Description;
                    suppplier.PhoneNumber = request.PhoneNumber;
                    suppplier.RatingReceived = request.RatingReceived;

                    _fuhoDbContext.Suppliers.Update(suppplier);
                    await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                else
                {
                    throw new NullResult(nameof(Supplier), nameof(request.SupplierId));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}