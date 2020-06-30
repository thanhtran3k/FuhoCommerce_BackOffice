using FuhoCommerce.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Query.GetOrderByUserId
{
    public class GetOrderByUserIdHandler : IRequestHandler<GetOrderByUserIdQuery, OrderListVm>
    {
        private readonly IFuhoDbContext _fuhoDbContext;
        private readonly ILogger<GetOrderByUserIdHandler> _logger;

        public GetOrderByUserIdHandler(IFuhoDbContext fuhoDbContext, ILogger<GetOrderByUserIdHandler> logger)
        {
            _fuhoDbContext = fuhoDbContext;
            _logger = logger;
        }

        public async Task<OrderListVm> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetCategoryByIdhandler - Get product by id");

            var result = await _fuhoDbContext.Orders
                .AsNoTracking()
                .Where(x => x.CreatedBy == request.UserId)
                .Include(x => x.OrderDetail)
                .Include(x => x.Shipper)
                .Select(x => new OrderDto
                {
                    OrderId = x.OrderId,
                    OrderDetail = x.OrderDetail,
                    Shipper = x.Shipper
                })
                .ToListAsync(cancellationToken);

            var orderListVm = new OrderListVm
            {
                OrderDtos = result
            };

            return orderListVm;
        }
    }
}
