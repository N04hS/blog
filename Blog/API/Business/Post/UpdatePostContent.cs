using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.Models;

namespace Blog.API.Business.Post;

public record UpdatePostContent(int PostId, string Content) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostContent>
    {
        public Task<Unit> Handle(UpdatePostContent request, CancellationToken cancellationToken)
        {
            var post = PostDataStore.Current.Posts.Single(p => p.Id == request.PostId);

            post.Content = request.Content;
            return Task.FromResult<Unit>(default);
        }
    }
}
