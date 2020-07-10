using FuhoCommerce.Application.UseCases.ProductUseCases.Command.CreateProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Command.UpdateProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProductsSC;
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

        [Authorize(Policy = "Consumer")]
        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetProductsSC(string userId, [FromQuery] int page = 1, int pageSize = 1)
        {
            var result = await Mediator.Send(new GetAllProductsSCQuery() { Page = page, PageSize = pageSize, UserId = userId });
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Invalid product id");
            }

            var result = await Mediator.Send(new GetProductByIdQuery(){ProductId = id});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Mediator.Send(command);
            return Ok();
        }

        [Authorize(Policy = "Consumer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Invalid product id");
            }

            await Mediator.Send(new RemoveProductCommand() { ProductId = id });
            return Ok();
        }
    }
}
