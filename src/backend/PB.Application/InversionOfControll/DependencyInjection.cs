using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PB.Application.Service;
using PB.Application.Service.Interfaces;
using PB.Data;

namespace PB.Application.InversionOfControll
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //DbContext
            services.AddDbContext<SocialMediaDbContext>(opt =>
                opt.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            //Interfaces Injections
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IGroupService, GroupService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
