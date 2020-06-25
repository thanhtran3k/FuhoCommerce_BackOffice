using FuhoCommerce.Application.UseCases.OrderUserCases.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Command
{
    public class CreateOrderResponse
    {
        public OrderDto OrderDto { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMessageCode { get; set; }

        public CreateOrderResponse() { }

        public CreateOrderResponse(CreateOrderResponse other)
        {
            OrderDto = other.OrderDto != null ? other.OrderDto : null;
            ErrorCode = other.ErrorCode;
            ErrorMessage = other.ErrorMessage;
            ErrorMessageCode = other.ErrorMessageCode;
        }
    }
}
