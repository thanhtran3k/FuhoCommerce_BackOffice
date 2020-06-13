using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Shipper
    {
        public Guid ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public Order Order { get; set; }
    }
}
