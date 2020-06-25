using FuhoCommerce.Application.UseCases.CommentUseCases.Command.CreateComment;
using FuhoCommerce.Application.UseCases.CommentUseCases.Command.RemoveComment;
using FuhoCommerce.Application.UseCases.CommentUseCases.Command.UpdateComment;
using FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FuhoCommerce.ApplicationApi.Controllers
{
    [Authorize]
    public class CommentController : BaseController
    {
        [HttpGet("{productId}")]
        public async Task<ActionResult<CommentListVm>> GetCommentByProductId(Guid productId, [FromQuery] int page = 1, int pageSize = 1)
        {
            var result = await Mediator.Send(new GetCommentByProductIdQuery(){ ProductId = productId, Page = page, PageSize = pageSize});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await Mediator.Send(new RemoveCommentCommand() { CommentId = id });
            return Ok();
        }
    }
}
