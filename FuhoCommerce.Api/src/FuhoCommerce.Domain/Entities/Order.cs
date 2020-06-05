using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Buyer Buyer { get; set; }
        public Shipper Shipper { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
