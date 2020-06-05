using FuhoCommerce.Domain.Common;
using FuhoCommerce.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class Buyer : BaseEntity
    {
        public Guid BuyerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactPhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Avatar { get; set; }

        public BuyerCart BuyerCart { get; set; }
        public ICollection<BuyerHistory> BuyerHistories { get; set; }
        public ICollection<BuyerShippingInfo> BuyerShippingInfos { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
