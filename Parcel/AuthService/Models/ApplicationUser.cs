using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)] 
        public string Name { get; set; }
        [StringLength(255)] 
        public string Surname { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
