using MediatR;
using System;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.RemoveComment
{
    public class RemoveCommentCommand : IRequest
    {
        public Guid CommentId { get; set; }
    }
}
