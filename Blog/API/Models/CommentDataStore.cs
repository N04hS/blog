using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Models;

public class CommentDataStore
{
    public List<CommentDto> Comments { get; set; }
    public static CommentDataStore Current { get; set; } = new CommentDataStore();

    public CommentDataStore()
    {
        Comments = new List<CommentDto>()
        {
            new CommentDto()
            {
                Id = 1,
                AuthorId = 2,
                PostId = 1,
                Content = "Tobias war hier"
            },
            new CommentDto()
            {
                Id = 2,
                AuthorId = 3,
                PostId = 1,
                Content = "Adrian war auch hier"
            },
            new CommentDto()
            {
                Id = 3,
                AuthorId = 1,
                PostId = 2,
                Content = "Hallo Tobias"
            }
        };
    }
}
