using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.CustomIdentityUser
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public bool IsSupplier { get; set; }
    }
}
