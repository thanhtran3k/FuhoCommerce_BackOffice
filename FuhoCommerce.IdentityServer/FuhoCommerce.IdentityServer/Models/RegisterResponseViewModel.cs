using FuhoCommerce.Persistence.CustomIdentityUser;

namespace FuhoCommerce.IdentityServer.Models
{
    public class RegisterResponseViewModel
    {
        public RegisterResponseViewModel(AppUser user)
        {
            Id = user.Id;
            //Name = user.Name;
            Email = user.Email;
        }

        public string Id { get; set; }
        //public string Name { get; set; }
        public string Email { get; set; }
    }
}
