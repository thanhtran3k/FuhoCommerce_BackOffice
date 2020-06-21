using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid CommentId { get; set; }
        public Guid ProductId { get; set; }
        public string Content { get; set; }
        public bool IsEdit { get; set; }
        public int  Rating { get; set; }

        public Product Product { get; set; }
    }
}
