using FuhoCommerce.Application.UseCases.ProductUseCases.Command.RemoveProduct;
using FuhoCommerce.Application.UseCases.ProductUseCases.Query.GetAllProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //[HttpPost]
        //public async Task<IActionResult> CreateProduct()
        //{

        //}

        [Authorize(Policy = "Consumer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await Mediator.Send(new RemoveProductCommand() { ProductId = id });
            return Ok();
        }
    }
}
