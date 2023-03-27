using Microsoft.EntityFrameworkCore;
using PB.Domain.Entities;

namespace PB.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options) 
        { 
        
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
