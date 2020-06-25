using FuhoCommerce.Application.UseCases.OrderUserCases.Command;
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
