using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class ProductOption : BaseEntity
    {
        public Guid ProductOptionId { get; set; }
        public string Optionkey { get; set; }
        public string OptionValues { get; set; }

        public Product Product { get; set; }
    }
}
