using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(256)]
    public string? Content { get; set; }

    [Required]
    [MaxLength(128)]
    public string Author { get; set; }
        = string.Empty;

    public DateTime TimeOfCreation { get; set; }

    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();

    public Post(string title)
    {
        Title = title;
        //TimeOfCreation = DateTime.Now;
    }
}
