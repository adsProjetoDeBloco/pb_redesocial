
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PB.Data.Service;
using PB.Domain.Interfaces;


namespace PB.Data.InversionOfControll
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //DbContext
            services.AddDbContext<SocialMediaDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            //Interfaces Injections
           
            services.AddScoped<IGameService, GameService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
