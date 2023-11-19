using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class CommentForCreationDto
{
    [Required(ErrorMessage = "You should provide an author id value!")]
    public int AuthorId { get; set; }

    [Required(ErrorMessage = "You should provide a content value!")]
    [MaxLength(256)]
    public string Content { get; set; } = string.Empty;
}
