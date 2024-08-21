using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace OcbuuCore.Injectors
{
    // Since we have to bring in WebApplicationBuilder for this class,
    // so this class is not implementing IInjetor but stay by itself.
    public static class SerilogInjector
    {
        public static void InjectSerilogSetup(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day));
        }
    }
}