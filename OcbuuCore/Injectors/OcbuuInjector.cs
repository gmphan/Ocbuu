using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Ocbuu.DataAcess;
using Ocbuu.DataAcess.Repository;
using Ocbuu.DataAcess.Repository.IRepository;
using Ocbuu.Services;

namespace OcbuuCore.Injectors
{
    public class OcbuuInjector : IInjector
    {
        public void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            // Inject from DataAccess services
            //services.AddDbContext<AzureSqlDbContext>(Options => Options.UseSqlServer(
            //                       configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AzurePgDbContext>(Options => Options.UseNpgsql(
                                    configuration.GetConnectionString("PostgresConnection")));
            services.AddScoped<IUnityOfWork, UnitiyOfWork>();

            // inject from Ocbuu.Services
            services.AddScoped<IResumeServices, ResumerServices>();
            // Register the IEmailSender service with your EmailSender implementation
            services.AddTransient<IEmailSender, EmailSenderServ>();

        }
    }
}