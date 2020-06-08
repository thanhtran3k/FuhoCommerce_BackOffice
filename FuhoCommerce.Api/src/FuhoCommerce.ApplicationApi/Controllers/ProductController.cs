using FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetProductById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ProductListVm>> GetAllProducts([FromQuery] int page, int pageSize)
        {
            var result = await Mediator.Send(new GetAllProductsQuery() { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProductById([FromQuery] Guid productId)
        {
            var result = await Mediator.Send(new GetProductByIdQuery(){ProductId = productId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [Authorize(Policy = "Consumer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await Mediator.Send(new RemoveProductCommand() { ProductId = id });
            return Ok();
        }
    }
}
