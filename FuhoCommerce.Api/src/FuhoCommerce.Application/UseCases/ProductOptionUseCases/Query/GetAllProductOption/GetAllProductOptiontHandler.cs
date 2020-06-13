using AutoMapper;
using FuhoCommerce.Application.Common.Interfaces;
using FuhoCommerce.Application.UseCases.ProductOptionUseCases.Query.GetAllProductOption;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.ProductOptionsUseCases.Query.GetAllProductOption
{
    public class GetAllProductOptionsHandler : IRequestHandler<GetAllProductOptionQuery, ProductOptionListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;

        public GetAllProductOptionsHandler(IFuhoDbContext fuhoDbContext, IMapper mapper)
        {
            _fuhoDbContext = fuhoDbContext;
        }

        public async Task<ProductOptionListVm> Handle(GetAllProductOptionQuery request, CancellationToken cancellationToken)
        {
            var productList = await _fuhoDbContext.ProductOptions
                .OrderByDescending(x => x.CreateDate)
                .Select(x => new ProductOptionDto
                {
                   
                })
                .ToListAsync();

            var productListVm = new ProductOptionListVm
            {
                ProductOptionDtos = productList
            };

            return productListVm;
        }
    }
}
