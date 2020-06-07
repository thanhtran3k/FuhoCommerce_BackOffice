using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FuhoCommerce.Persistence.CustomIdentityUser
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Name = string.Concat(FirstName, LastName);
        }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string VendorDescription { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
