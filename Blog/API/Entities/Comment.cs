using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.API.Entities;

public class Comment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("PostId")]
    public Post? Post { get; set; }
    public int PostId { get; set; }

    [Required]
    [MaxLength(256)]
    public string Content { get; set; }

    [Required]
    [MaxLength(128)]
    public string Author { get; set; }
        = string.Empty;

    public DateTime TimeOfCreation { get; set; }

    public Comment(string content)
    {
        Content = content;
    }
}
