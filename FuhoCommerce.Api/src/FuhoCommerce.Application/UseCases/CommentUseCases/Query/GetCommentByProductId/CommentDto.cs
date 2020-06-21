using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Application.UseCases.CommentUseCases.Query.GetCommentByProductId
{
    public class CommentDto
    {
        public Guid CommentId { get; set; }
        public Guid ProductId { get; set; }
        public string Content { get; set; }
        public bool IsEdit { get; set; }
        public int Rating { get; set; }
    }
}
