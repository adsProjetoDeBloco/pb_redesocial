using Microsoft.EntityFrameworkCore;
using PB.Domain.Entities;


namespace PB.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public SocialMediaDbContext(DbContextOptions<SocialMediaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Relação de N para N Grupo e Usuario
            builder.Entity<UserGroup>()
                .HasKey(uG => new { uG.UserId, uG.GroupId });

            builder.Entity<UserGroup>()
                .HasOne(u => u.User)
                .WithMany(g => g.Groups)
                .HasForeignKey(f => f.UserId);

            builder.Entity<UserGroup>()
                .HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(f => f.GroupId);
            //------------------------------------------

            //Relação de N para N Usuario e Jogos
            builder.Entity<UserGame>()
                .HasKey(uG => new { uG.UserId, uG.GameId });

            builder.Entity<UserGame>()
                .HasOne(u => u.User)
                .WithMany(g => g.Games)
                .HasForeignKey(f => f.UserId);

            builder.Entity<UserGame>()
                .HasOne(u => u.Game)
                .WithMany(g => g.Users)
                .HasForeignKey(f => f.GameId);
            //------------------------------------------


            //Relação de N para N Usuario e Seguidores

            builder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.FollowedUser)
                .HasForeignKey(f => f.FollowedUserId);

            builder.Entity<UserFollowers>()
                .HasKey(uf => new { uf.FollowerId, uf.FollowedUserId });

            builder.Entity<UserFollowers>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Following)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserFollowers>()
                .HasOne(uf => uf.FollowedUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            //------------------------------------------

            //Comentario tem um usuario e um usuario tem varios comentarios
            builder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //comentario tem um post e um post tem N comentarios
            builder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(f => f.PostId);



            //um post tem um usuario com varios posts.
            builder.Entity<Post>()
                .HasOne(u => u.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.UserId);

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserFollowers> UserFollowers { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

    }
}
