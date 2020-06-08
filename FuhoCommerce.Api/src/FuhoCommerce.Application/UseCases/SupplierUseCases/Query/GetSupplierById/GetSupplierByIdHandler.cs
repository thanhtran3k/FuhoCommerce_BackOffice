using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetAllSuppliers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetSupplierById
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, SupplierDto>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetSupplierByIdHandler> _logger;

        public GetSupplierByIdHandler(IFuhoDbContext fuhoDbContext)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<SupplierDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetSupplierByIdhandler - Get product by id");

            var result = await _fuhoDbContext.Suppliers
                .AsNoTracking()
                .Where(x => x.SupplierId == request.SupplierId)
                .Select(x => new SupplierDto
                {
                    SupplierId = x.SupplierId,
                    Name = x.Name,
                    Email = x.Email,
                    Address = x.Address,
                    Description = x.Description,
                    PhoneNumber = x.PhoneNumber,
                    RatingReceived = x.RatingReceived
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            return result;
        }
    }
}