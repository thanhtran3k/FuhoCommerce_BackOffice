using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Command.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public Guid CommentId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

    }
}