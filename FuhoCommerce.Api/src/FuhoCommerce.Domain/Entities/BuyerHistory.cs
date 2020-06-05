using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class BuyerHistory : BaseEntity
    {
        public Guid BuyerHistoryId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
