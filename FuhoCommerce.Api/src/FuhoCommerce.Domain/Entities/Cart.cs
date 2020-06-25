using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid CartId { get; set; }
        public string ListProduct { get; set; }
    }
}
