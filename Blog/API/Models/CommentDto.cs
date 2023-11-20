using Blog.API.Entities;

namespace Blog.API.Models;

public class CommentDto
{
    public CommentDto()
    {
        TimeOfCreation = DateTime.Now;
    }

    public CommentDto(Comment comment)
    {
        Id = comment.Id;
        Author = comment.Author;
        PostId = comment.PostId;
        Content = comment.Content;
        TimeOfCreation = comment.TimeOfCreation;
    }

    public int Id { get; set; }
    public string Author { get; set; }
        = string.Empty;
    public int PostId { get; set; }
    public DateTime TimeOfCreation { get; /*set;*/ }
    public string Content { get; set; } = string.Empty;


}
