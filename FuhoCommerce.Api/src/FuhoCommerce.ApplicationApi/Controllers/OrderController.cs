using FuhoCommerce.Application.UseCases.OrderUserCases.Command;
using FuhoCommerce.Application.UseCases.OrderUserCases.Query.GetOrderByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        [HttpGet("userId")]
        public async Task<IActionResult> GetOrder([FromQuery] string userId)
        {
            var result = await Mediator.Send(new GetOrderByUserIdQuery() { UserId = userId });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
