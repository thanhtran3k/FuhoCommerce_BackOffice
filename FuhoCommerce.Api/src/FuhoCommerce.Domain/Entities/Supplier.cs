using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public int RatingReceived { get; set; }

        public ICollection<SupplierCategory> SupplierCategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
