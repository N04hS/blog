namespace Blog.API.Models;

public class PostDto
{
    public int Id { get; set; }
    //public int AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public int NumberOfComments => Comments.Count;
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
}
