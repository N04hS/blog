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
                        TimeOfCreation = DateTime.Parse("24.10.2023 10:26"),
                        Comments = new List<CommentDto>()
                        {
                            new CommentDto()
                            {
                                Id = 1,
                                AuthorId = 2,
                                Content = "Tobias war hier",
                                TimeOfCreation = DateTime.Parse("24.10.2023 10:45")
                            },
                            new CommentDto()
                            {
                                Id = 2,
                                AuthorId = 3,
                                Content = "Adrian war hier",
                                TimeOfCreation = DateTime.Parse("24.10.2023 10:53")
                            },
                            new CommentDto()
                            {
                                Id = 3,
                                AuthorId = 2,
                                Content = "Tobias war nochmal hier",
                                TimeOfCreation = DateTime.Parse("24.10.2023 11:17")
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
