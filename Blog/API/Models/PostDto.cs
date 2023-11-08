namespace Blog.API.Models;

public class PostDto
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public DateTime TimeOfCreation { get; /*set;*/ }

    public PostDto()
    {
        TimeOfCreation = DateTime.Now;
    }
}
