using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class UserShippingInfo : BaseEntity
    {
        public UserShippingInfo()
        {
            ShippingAddress = string.Join(" - ", Number, StreetName, Ward, District, City, Country);
        }
        public string Number { get; set; }
        public string StreetName { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDefault { get; set; }
    }
}
