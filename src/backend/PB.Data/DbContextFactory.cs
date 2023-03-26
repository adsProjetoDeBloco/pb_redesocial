using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PB.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<SocialMediaDbContext>
    {
        public SocialMediaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SocialMediaDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
            return new SocialMediaDbContext(optionsBuilder.Options);
        }
    }
}
