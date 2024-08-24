using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ocbuu.DataAcess;
using Ocbuu.Models;

namespace OcbuuCore.Injectors
{
    public class IdentityInjector : IInjector
    {
        public void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            /*  Authentication setup */
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AzurePgDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });
        }
    }
}