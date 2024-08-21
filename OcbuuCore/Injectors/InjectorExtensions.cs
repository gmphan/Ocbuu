using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcbuuCore.Injectors
{
    public static class InjectorExtensions
    {
        // this should be a static class, so its properties can be called without initializing an object from it
        public static void InjectServicesFromAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            // create a list of injector instance from this injectors namespace
            // I need to read more about how this injector list of object is created
            var injectors = typeof(Program).Assembly.ExportedTypes
                .Where( x => typeof(IInjector).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInjector>()
                .ToList();

            // loop through each injector object to give assign services and configuration as requested
            injectors.ForEach(injector => {
                injector.InjectServices(services, configuration);
            });
        } 
    }
}