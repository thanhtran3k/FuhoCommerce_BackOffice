using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
