using Blog.API.Entities;
using System.Reflection;

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
        AuthorId = comment.AuthorId;
        Content = comment.Content;
        TimeOfCreation = comment.TimeOfCreation;
    }

    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int PostId { get; set; }
    public DateTime TimeOfCreation { get; /*set;*/ }
    public string Content { get; set; } = string.Empty;


}
