using FuhoCommerce.Application.UseCases.SupplierUseCases.Command.CreateSupplier;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Command.RemoveSupplier;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Command.UpdateSupplier;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetAllSuppliers;
using FuhoCommerce.Application.UseCases.SupplierUseCases.Query.GetSupplierById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [Authorize]
    public class SupplierController : BaseController
    {
        [HttpGet]
        //[AllowAnonymous]
        public async Task<ActionResult<SupplierListVm>> GetAllSuppliers()
        {
            var result = await Mediator.Send(new GetAllSuppliersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<SupplierDto>> GetSupplierById([FromQuery] Guid productId)
        {
            var result = await Mediator.Send(new GetSupplierByIdQuery(){SupplierId = productId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [Authorize(Policy = "Supplier")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSupplier(Guid id)
        {
            await Mediator.Send(new RemoveSupplierCommand() { SupplierId = id });
            return Ok();
        }
    }
}
