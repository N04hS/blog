namespace Blog.API.Models;

public class CommentDto
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Content { get; set; } = string.Empty;
}
