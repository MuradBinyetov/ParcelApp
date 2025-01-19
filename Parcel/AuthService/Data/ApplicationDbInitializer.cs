using AuthService.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Data
{
    public class ApplicationDbInitializer
    {

        private const string DefaultRole = SystemRoles.AdminRole;
        private const string DefaultUserName = "Admin";
        private const string DefaultName = "Admin";
        private const string DefaultSurname = "Admin";
        private const string DefaultEmail = "admin@gmail.com";
        private const string DefaultPassword = "admin162134Ws!";

        public static async Task SeedDefaultUserAndRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            IdentityResult roleCreated;
            if (await roleManager.FindByNameAsync(DefaultRole) == null)
            {
                var defaultRole = new ApplicationRole
                {
                    Name = DefaultRole
                };
                roleCreated = await roleManager.CreateAsync(defaultRole);
            }
            else
            {
                roleCreated = IdentityResult.Success;
            }

            if (roleCreated.Succeeded)
            {
                if (await userManager.FindByEmailAsync(DefaultEmail) == null)
                {
                    var defaultUser = new ApplicationUser()
                    {
                        UserName = DefaultUserName,
                        Name = DefaultName,
                        Surname = DefaultSurname,
                        Email = DefaultEmail
                    };
                    var result = await userManager.CreateAsync(defaultUser, DefaultPassword);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(defaultUser, DefaultRole);
                    }
                }
            }
        }




        public static async Task<IdentityResult> SeedRolesAsync(RoleManager<ApplicationRole> roleManager)
        {
            IdentityResult result = IdentityResult.Failed();

            foreach (string role in SystemRoles.AllRoles)
            {
                if (await roleManager.FindByNameAsync(role) != null) continue;
                result = await roleManager.CreateAsync(new ApplicationRole
                {
                    Name = role
                });
            }
            return result;
        }
    }
}
