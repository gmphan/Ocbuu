using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Ocbuu.Models;

namespace OcbuuCore.Injectors
{
    public class AdminSeederInjector
    {
        /* 
            This class is used to inject a default admin user
            for initial application start up. It doesn't need 
            IInjector.cs because it doesn't need to inject any
            service but using service to inject the admin user.
         */        
        private readonly ILogger<AdminSeederInjector> _logger;
        private readonly InitAdminUser  _initAdminUser;
        public AdminSeederInjector(ILogger<AdminSeederInjector> logger
                                , IOptions<InitAdminUser> options)
        {
            _logger = logger;
            _initAdminUser = options.Value;
        }
        public async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            // Get the UserManager and RoleManager services
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure that the Admin role exists
            if (!await roleManager.RoleExistsAsync(_initAdminUser.AdminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(_initAdminUser.AdminRole));
            }

            // Check if the admin user already exists
            var adminUser = await userManager.FindByEmailAsync(_initAdminUser.AdminEmail);
            if (adminUser == null)
            {
                // Create the admin user if they don't exist
                adminUser = new IdentityUser
                {
                    UserName = _initAdminUser.AdminEmail,
                    Email = _initAdminUser.AdminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, _initAdminUser.AdminPassword);

                // If the user is created successfully, assign the Admin role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, _initAdminUser.AdminRole);
                }
            }
        }
    }
}