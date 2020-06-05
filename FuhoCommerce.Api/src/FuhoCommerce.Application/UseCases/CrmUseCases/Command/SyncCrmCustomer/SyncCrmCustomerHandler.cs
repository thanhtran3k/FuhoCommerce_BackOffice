using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.CrmUseCases.Command.SyncCrmCustomer
{
    public class SyncCrmCustomerHandler : IRequestHandler<SyncCrmCustomerCommand>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        public SyncCrmCustomerHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<Unit> Handle(SyncCrmCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.IsSupplier)
                {
                    var supplier = new Supplier()
                    {
                        SupplierId = request.UserId,
                        Email = request.Email,
                    };

                    _fuhoDbContext.Suppliers.Add(supplier);
                } else
                {
                    var buyer = new Buyer()
                    {
                        BuyerId = request.UserId,
                        Email = request.Email,
                    };

                    _fuhoDbContext.Buyers.Add(buyer);
                }

                await _fuhoDbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
