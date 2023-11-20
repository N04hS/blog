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
        Author = post.Author;
        Title = post.Title;
        Content = post.Content!;
        TimeOfCreation = post.TimeOfCreation;
        Comments = post.Comments
            .Select(c => new CommentDto(c))
            .ToList();
    }

    public int Id { get; set; }
    public string Author { get; set; }
        = string.Empty;
    public string Title { get; set; }
        = string.Empty;
    public string Content { get; set; } 
        = string.Empty;

    public DateTime TimeOfCreation { get; }

    public int NumberOfComments => Comments.Count;

    public ICollection<CommentDto> Comments { get; set; } 
        = new List<CommentDto>();
}
