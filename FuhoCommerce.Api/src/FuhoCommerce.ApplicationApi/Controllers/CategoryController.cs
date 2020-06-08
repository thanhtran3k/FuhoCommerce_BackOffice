﻿using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.CreateCategory;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.RemoveCategory;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Command.UpdateCategory;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetAllCategories;
using FuhoCommerce.Application.UseCases.CategoryUseCases.Query.GetCategoryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    //[Authorize]
    public class CategoryController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryListVm>> GetAllCategorys()
        {
            var result = await Mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryDto>> GetCategoryById([FromQuery] Guid productId)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery(){CategoryId = productId});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            await Mediator.Send(new RemoveCategoryCommand() { CategoryId = id });
            return Ok();
        }
    }
}
