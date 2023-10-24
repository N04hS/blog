namespace Blog.API.Models;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int NumberOfPosts => Posts.Count;
    public ICollection<PostDto> Posts { get; set; }
        = new List<PostDto>();
    
    /*
    public ICollection<CommentDto> Comments { get; set; }
        = new List<CommentDto>();
    */
}
