using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.CreateComment
{
    public class CreateCommentCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
