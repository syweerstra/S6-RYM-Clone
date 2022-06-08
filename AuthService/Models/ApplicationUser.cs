using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string username)
        {
            this.UserName = username;
        }
    }
}
