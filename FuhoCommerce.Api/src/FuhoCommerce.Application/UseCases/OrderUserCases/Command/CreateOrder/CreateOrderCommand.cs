using FuhoCommerce.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Application.UseCases.OrderUserCases.Command
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Shipper Shipper { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
