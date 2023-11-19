using Blog.API.Entities;

namespace Blog.API.Models;

public class UserDto
{
    public UserDto() { }
    public UserDto(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Posts = user.Posts
            .Select(p => new PostDto(p))
            .ToList();
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public int NumberOfPosts => Posts.Count;

    public ICollection<PostDto> Posts { get; set; }
        = new List<PostDto>();
}
