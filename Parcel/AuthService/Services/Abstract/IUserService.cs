using AuthService.Models;

namespace AuthService.Services.Abstract
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByUsernameAsync(string username);
    }
}
