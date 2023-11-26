using Blog.API.DbContexts;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record GetCommentCountByPost(int PostId) : IQuery<int>
{
    public class Handler : IRequestHandler<GetCommentCountByPost, int>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<int> Handle(GetCommentCountByPost request, CancellationToken cancellationToken)
        {
            var post = await context.Posts
                .SingleAsync(p => p.Id == request.PostId, cancellationToken);

            return post.Comments.Count;
        }
    }
}
