namespace Blog.API.Models;

public class PostDataStore
{
    public List<PostDto> Posts { get; set; }
    public static PostDataStore Current { get; set; } = new PostDataStore();

    public PostDataStore()
    {
        Posts = new List<PostDto>()
        {
            new PostDto()
            {
                Id = 1,
                AuthorId = 1,
                Title = "Noahs Post",
                Content = "Hallo, ich heiße Noah"
            },
            new PostDto()
            {
                Id = 2,
                AuthorId = 2,
                Title = "Tobias' Post",
                Content = "Hallo, ich heiße Tobias"
            }
        };
    }
}
