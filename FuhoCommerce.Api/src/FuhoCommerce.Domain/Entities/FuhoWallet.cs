using FuhoCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Domain.Entities
{
    public class FuhoWallet : BaseEntity
    {
        public Guid FuhoWalletId { get; set; }
        public decimal FuhoMoney { get; set; }
        public decimal FuhoCoin { get; set; }
        public DateTime FuhoCoinExpiryDate { get; set; }
    }
}
