using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("AuthorId")]
    public User? Author { get; set; }
    public int AuthorId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [Required]
    [MaxLength(256)]
    public string Content { get; set; }

    public DateTime TimeOfCreation { get; set; }

    public Post(string title)
    {
        Title = title;
        //TimeOfCreation = DateTime.Now;
    }
}
