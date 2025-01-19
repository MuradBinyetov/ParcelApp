using AuthService.Data;
using AuthService.Models;
using AuthService.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;    


        public UserService(UserManager<ApplicationUser> userManager)
        { 
            _userManager = userManager; 
        }


        public async Task<ApplicationUser> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username)) return null;
            ApplicationUser user = await _userManager.FindByNameAsync(username);
            return user == null ? null : user;
        }
    }
}
