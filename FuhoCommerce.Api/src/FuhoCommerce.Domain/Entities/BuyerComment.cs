using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class BuyerComment : BaseEntity
    {
        public Guid BuyerCommentId { get; set; }
        public Guid ProductId { get; set; }
        public string Content { get; set; }

        public Product Product { get; set; }
    }
}
