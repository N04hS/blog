using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("AuthorId")]
    public User? Author { get; set; }
    public int AuthorId { get; set; }

    [ForeignKey("PostId")]
    public Post? Post { get; set; }
    public int PostId { get; set; }

    [Required]
    [MaxLength(256)]
    public string Content { get; set; }

    public DateTime TimeOfCreation { get; set; }

    public Comment(string content)
    {
        Content = content;
    }
}
