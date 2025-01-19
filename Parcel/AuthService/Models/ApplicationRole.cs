using Microsoft.AspNetCore.Identity;

namespace AuthService.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
