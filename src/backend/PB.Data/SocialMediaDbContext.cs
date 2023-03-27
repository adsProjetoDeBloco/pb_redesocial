using Microsoft.EntityFrameworkCore;
using PB.Domain.Entities;

namespace PB.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder builder){

            //um post tem N comentarios e um comentario
            builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post);
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
