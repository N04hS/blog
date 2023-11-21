using Blog.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.DbContexts;

public class BlogContext : IdentityDbContext<User>
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;

    public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * add-migration "MigrationName"
         * update-database
         */

        modelBuilder.Entity<Post>()
            .HasData(
            new Post("Feilhauer Prüfung")
            {
                Id = 1,
                Author = "Noah Siess",
                Content = "Fandet ihr die Feilhauer Prüfung auch so schwer?",
                TimeOfCreation = DateTime.Parse("01.07.2023")
            },
            new Post("Tobias' Post")
            {
                Id = 2,
                Author = "Tobias Loacker",
                Content = "Lorem ipsum",
                TimeOfCreation = DateTime.Parse("01.07.2023")
            });

        modelBuilder.Entity<Comment>()
            .HasData(
            new Comment("Die war richtig ehrenlos!")
            {
                Id = 1,
                Author = "Adrian Bernhard",
                PostId = 1,
                TimeOfCreation = DateTime.Parse("01.07.2023")
            },
            new Comment("Mit genug Anstrengung wäre diese Prüfung ein leichtes gewesen. :)")
            {
                Id = 2,
                Author = "Thomas Feilhauer",
                PostId = 1,
                TimeOfCreation = DateTime.Parse("13.08.2023")
            },
            new Comment("Das Feedback zur Prüfung ist schon sehr intransparent!")
            {
                Id = 3,
                Author = "Deniz Frick",
                PostId = 1,
                TimeOfCreation = DateTime.Parse("14.08.2023")
            });

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>().Navigation(x => x.Comments).AutoInclude();
    }
}
