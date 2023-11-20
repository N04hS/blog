using Blog.API.Entities;

namespace Blog.API.Models;

public class UserDto
{
    public UserDto() { }
    public UserDto(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
