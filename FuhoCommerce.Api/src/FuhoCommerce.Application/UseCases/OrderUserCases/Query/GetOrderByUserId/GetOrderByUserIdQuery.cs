using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Query.GetOrderByUserId
{
    public class GetOrderByUserIdQuery : IRequest<OrderListVm>
    {
        public string UserId { get; set; }
    }
}
