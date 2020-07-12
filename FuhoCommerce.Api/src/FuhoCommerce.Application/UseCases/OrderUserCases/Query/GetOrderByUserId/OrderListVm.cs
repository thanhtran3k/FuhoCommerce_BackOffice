using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Query.GetOrderByUserId
{
    public class OrderListVm
    {
        public ICollection<OrderDto> OrderDtos { get; set; }
    }
}
