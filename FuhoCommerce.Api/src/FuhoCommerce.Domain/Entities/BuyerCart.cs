using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class BuyerCart : BaseEntity
    {
        public Guid BuyerCartId { get; set; }
        public Guid BuyerId { get; set; }

        public Buyer Buyer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
