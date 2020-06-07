using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class BuyHistory : BaseEntity
    {
        public Guid BuyHistoryId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
