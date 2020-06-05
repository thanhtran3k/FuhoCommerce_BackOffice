using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class BuyerShippingInfo : BaseEntity
    {
        public BuyerShippingInfo()
        {
            ShippingAddress = string.Join(" - ", Number, StreetName, Ward, District, City, Country);
        }

        public Guid BuyerShippingInfoId { get; set; }
        public Guid BuyerId { get; set; }
        public string Number { get; set; }
        public string StreetName { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ShippingAddress { get; set; }
        public string PhoneNumber { get; set; }

        public Buyer Buyer { get; set; }
    }
}
