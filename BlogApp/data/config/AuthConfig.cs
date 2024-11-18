using BlogApp.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Data.Config
{

    public static class AuthConfig
    {
        internal static class Admin
        {
            public const string userName = "admin";
            public const string password = "TenDigitPassword";
            public const string roleName = "Administrator";

            public static BlogUser BlogUserObject() => new BlogUser {UserName = userName, FirstName = "root", LastName = "default-admin-ccount"};
        }

        public static async Task ConfigAdmin(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetService<UserManager<BlogUser>>();

            if (await roleManager.FindByNameAsync(Admin.roleName) == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(Admin.roleName));
                if (result.Succeeded)
                {
                    Console.WriteLine($"{Admin.userName} account Added to DB");
                }
                else
                {
                    Console.WriteLine($"{Admin.userName} is already created in DB");
                }
            }

            if (await userManager.FindByNameAsync(Admin.userName) == null)
            {
                BlogUser adminUser = Admin.BlogUserObject();
                var result = await userManager.CreateAsync(adminUser, Admin.password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Admin.roleName);
                    Console.WriteLine($"{Admin.roleName} added to DB");
                }
                else
                {
                    Console.WriteLine("User & role not added. Database or program error.");
                }
            }
        }




    }


}