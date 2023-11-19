using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record AddPost(int AuthorId, string Title, string Content) : ICommand<PostDto>
{
    public class Handler : IRequestHandler<AddPost, PostDto>
    {
        public Task<PostDto> Handle(AddPost request, CancellationToken cancellationToken)
        {
            // check that user actually exists
            var user = UserDataStore.Current.Users.Single(u => u.Id == request.AuthorId);

            var nextId = PostDataStore.Current.Posts.Max(p => p.Id) + 1;

            var post = new PostDto()
            {
                Id = nextId,
                AuthorId = request.AuthorId,
                Title = request.Title,
                Content = request.Content
            };

            PostDataStore.Current.Posts.Add(post); 
            return Task.FromResult(post);
        }
    }
}
