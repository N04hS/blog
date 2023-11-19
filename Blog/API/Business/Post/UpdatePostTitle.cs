using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record UpdatePostTitle(int PostId, string Title) : ICommand
{
    public class Handler : IRequestHandler<UpdatePostTitle>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;
        
        public async Task<Unit> Handle(UpdatePostTitle request, CancellationToken cancellationToken)
        {
            var post = await context.Posts.SingleAsync(x => x.Id == request.PostId, cancellationToken);

            post.Title = request.Title;

            await context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}
