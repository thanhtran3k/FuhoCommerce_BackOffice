using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
