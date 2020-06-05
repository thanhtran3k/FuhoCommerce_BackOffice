using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class SupplierCategory : BaseEntity
    {
        public Guid SupplierCategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierCategoryName { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
