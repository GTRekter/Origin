using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Origin.Models.Store;

namespace Origin.Models
{
    public static class SeedData
    {
        public static async Task CreateAdminUserAndRole(ApplicationDbContext context, UserManager<OR_User> userManager, RoleManager<OR_Role> roleManager)
        {
            if (context.AllMigrationsApplied())
            {    
                if (false == await roleManager.RoleExistsAsync("Administrator"))
                {
                    var administratorRole = new OR_Role { Name = "Administrator" };
                    await roleManager.CreateAsync(administratorRole);
                }

                if (null == await userManager.FindByEmailAsync("administrator@origin.com"))
                {
                    var user = new OR_User { UserName = "administrator@origin.com", Email = "administrator@origin.com" };
                    await userManager.CreateAsync(user, "P@ssw0rd");
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
    }
}
