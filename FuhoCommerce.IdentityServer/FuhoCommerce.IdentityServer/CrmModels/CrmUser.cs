using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuhoCommerce.IdentityServer.CrmModels
{
    public class CrmUser
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool IsSupplier { get; set; }
    }
}
