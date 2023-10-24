namespace Blog.API.Models;

public class UserDataStore
{
    public List<UserDto> Users { get; set; }
    public static UserDataStore Current { get; set; } = new UserDataStore();

    public UserDataStore()
    {
        Users = new List<UserDto>()
        {
            new UserDto()
            {
                Id = 1,
                FirstName = "Noah",
                LastName = "Siess",
                Posts = new List<PostDto>()
                {
                    new PostDto()
                    {
                        Id = 1,
                        Title = "Titel",
                        Content = "Inhalt",
                        Comments = new List<CommentDto>()
                        {
                            new CommentDto()
                            {
                                Id = 1,
                                AuthorId = 2,
                                Content = "Tobias war hier"
                            },
                            new CommentDto()
                            {
                                Id = 2,
                                AuthorId = 3,
                                Content = "Adrian war hier"
                            },
                            new CommentDto()
                            {
                                Id = 3,
                                AuthorId = 2,
                                Content = "Tobias war nochmal hier"
                            }
                        }
                    }
                }
            },
            new UserDto()
            {
                Id = 2,
                FirstName = "Tobias",
                LastName = "Loacker"
            },
            new UserDto()
            {
                Id = 3,
                FirstName = "Adrian",
                LastName = "Bernhard"
            }
        };
    }
}
