using System.ComponentModel.DataAnnotations;

namespace Blog.API.Models;

public class PostForUpdateDto
{
    [Required(ErrorMessage = "You should provide a name value!")]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "You should provide a content value!")]
    [MaxLength(256)]
    public string Content { get; set; } = string.Empty;
}
