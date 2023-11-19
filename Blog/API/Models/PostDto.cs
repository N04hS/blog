using Blog.API.Entities;

namespace Blog.API.Models;

public class PostDto
{
    public PostDto()
    {
        TimeOfCreation = DateTime.Now;
    }

    public PostDto(Post post)
    {
        Id = post.Id;
        AuthorId = post.AuthorId;
        Title = post.Title;
        Content = post.Content;
        TimeOfCreation = post.TimeOfCreation;
    }

    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime TimeOfCreation { get; /*set;*/ }

  
}
