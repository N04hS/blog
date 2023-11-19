using Blog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.DbContexts;

public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;

    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * add-migration "MigrationName"
         * update-database
         */
        modelBuilder.Entity<User>()
            .HasData(
            new User("Noah", "Siess")
            {
                Id = 1
            },
            new User("Tobias", "Loacker")
            {
                Id = 2
            },
            new User("Adrian", "Bernhard")
            {
                Id = 3
            });

        modelBuilder.Entity<Post>()
            .HasData(
            new Post("Noahs Post")
            {
                Id = 1,
                AuthorId = 1,
                Content = "Hallo, ich heiße Noah",
                TimeOfCreation = DateTime.Now
            },
            new Post("Tobias' Post")
            {
                Id = 2,
                AuthorId = 2,
                Content = "Lorem ipsum",
                TimeOfCreation = DateTime.Now
            });

        base.OnModelCreating(modelBuilder);
    }
}
