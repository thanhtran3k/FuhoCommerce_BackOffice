using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Command.CreateSupplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand>
    {
        public readonly IFuhoDbContext _fuhoDbContext;

        public CreateSupplierHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<Unit> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newSupplier = new Supplier()
                {
                    SupplierId = request.SupplierId,
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                    RatingReceived = request.RatingReceived
                };

                _fuhoDbContext.Suppliers.Add(newSupplier);

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
