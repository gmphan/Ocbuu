using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcbuuCore.Injectors
{
    public class MvcInjector : IInjector
    {
        public void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
        }
    }
}