using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;

namespace FuhoCommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
