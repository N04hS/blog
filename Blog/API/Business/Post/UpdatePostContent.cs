using Fusonic.Extensions.MediatR;
using MediatR;
using Blog.API.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record UpdatePostContent(int PostId, string Content) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostContent>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Unit> Handle(UpdatePostContent request, CancellationToken cancellationToken)
        {
            var post = await context.Posts.SingleAsync(x => x.Id == request.PostId, cancellationToken);

            post.Content = request.Content;

            await context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}
