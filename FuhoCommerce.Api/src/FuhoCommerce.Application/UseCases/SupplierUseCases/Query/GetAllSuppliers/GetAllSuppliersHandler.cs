using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetAllSuppliers
{
    public class GetAllSuppliersHandler : IRequestHandler<GetAllSuppliersQuery, SupplierListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllSuppliersHandler(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<SupplierListVm> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var productList = await _fuhoDbContext.Suppliers
                .OrderByDescending(x => x.Name)
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
                .ToListAsync();

            var productListVm = new SupplierListVm
            {
                SupplierDtos = productList
            };

            return productListVm;
        }
    }
}
