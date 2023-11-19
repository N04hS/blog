using Blog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.DbContexts;

public class BlogContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * add-migration "MigrationName"
         * update-database
         */

        modelBuilder.Entity<User>().Navigation(x => x.Posts).AutoInclude();
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
            },
            new User("Reinhold", "Messner")
            {
                Id = 4
            },
            new User("Thomas", "Feilhauer")
            {
                Id = 5
            },
            new User("Deniz", "Frick")
            {
                Id = 6
            });

        modelBuilder.Entity<Post>().Navigation(x => x.Comments).AutoInclude();
        modelBuilder.Entity<Post>()
            .HasData(
            new Post("Feilhauer Prüfung")
            {
                Id = 1,
                AuthorId = 1,
                Content = "Fandet ihr die Feilhauer Prüfung auch so schwer?",
                TimeOfCreation = DateTime.Parse("01.07.2023")
            },
            new Post("Tobias' Post")
            {
                Id = 2,
                AuthorId = 2,
                Content = "Lorem ipsum",
                TimeOfCreation = DateTime.Parse("01.07.2023")
            });

        modelBuilder.Entity<Comment>()
            .HasData(
            new Comment("Die war richtig ehrenlos!")
            {
                Id = 1,
                AuthorId = 2,
                PostId = 1,
                TimeOfCreation = DateTime.Parse("01.07.2023")
            },
            new Comment("Mit genug Anstrengung wäre diese Prüfung ein leichtes gewesen. :)")
            {
                Id = 2,
                AuthorId = 5,
                PostId = 1,
                TimeOfCreation = DateTime.Parse("13.08.2023")
            },
            new Comment("Das Feedback zur Prüfung ist schon sehr intransparent!")
            {
                Id = 3,
                AuthorId = 6,
                PostId = 1,
                TimeOfCreation = DateTime.Parse("14.08.2023")
            });

        base.OnModelCreating(modelBuilder);
    }
}
