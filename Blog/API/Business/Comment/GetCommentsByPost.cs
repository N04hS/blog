using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record GetCommentsByPost(int PostId) : IQuery<GetCommentsByPost.Result>
{
    public record Result(IEnumerable<CommentDto> Items);

    public class Handler : IRequestHandler<GetCommentsByPost, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetCommentsByPost request, CancellationToken cancellationToken)
        {
            var post = await context.Posts.SingleAsync(p => p.Id == request.PostId, cancellationToken);

            return new Result(
                post.Comments
                .Select(c => new CommentDto(c))
                .ToList());
        }

    }
}
