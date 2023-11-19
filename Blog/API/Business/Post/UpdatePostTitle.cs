using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record UpdatePostTitle(int PostId, string Title) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostTitle>
    {
        public Task<Unit> Handle(UpdatePostTitle request, CancellationToken cancellationToken)
        {
            var post = PostDataStore.Current.Posts.Single(p => p.Id == request.PostId);

            post.Title = request.Title;
            return Task.FromResult<Unit>(default);
        }
    }
}
