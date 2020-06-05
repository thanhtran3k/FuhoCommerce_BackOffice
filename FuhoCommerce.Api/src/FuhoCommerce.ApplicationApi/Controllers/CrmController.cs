using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuhoCommerce.Application.UseCases.CrmUseCases.Command.SyncCrmCustomer;
using Microsoft.AspNetCore.Mvc;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    public class CrmController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SyncCrmCustomer(SyncCrmCustomerCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
