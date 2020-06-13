using FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.CreateProductOption;
using FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.RemoveProductOption;
using FuhoCommerce.Application.UseCases.ProductOptionUseCases.Command.UpdateProductOption;
using FuhoCommerce.Application.UseCases.ProductOptionUseCases.Query.GetAllProductOption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [Authorize]
    public class ProductOptionController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductOptionListVm>> GetAllProductOption()
        {
            var result = await Mediator.Send(new GetAllProductOptionQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductOption([FromBody] CreateProductOptionCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductOption([FromBody] UpdateProductOptionCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductOption(Guid id)
        {
            await Mediator.Send(new RemoveProductOptionCommand() { ProductOptionId = id });
            return Ok();
        }
    }
}
