using FuhoCommerce.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FuhoCommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int Stock { get; set; }
        public int? ReorderLevel { get; set; }
        public string Images { get; set; }

        public Category Category { get; set; }
        //Color: [Black, Red]
        public ICollection<ProductOption> ProductOptions { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
