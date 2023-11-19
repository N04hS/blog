using Blog.API.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Fusonic.Extensions.MediatR;

namespace Blog.API.Business.Comment;

public record UpdateComment(int CommentId, string Content) : ICommand
{
    public class Handler : IRequestHandler<UpdateComment>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Unit> Handle(UpdateComment request, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.SingleAsync(x => x.Id == request.CommentId, cancellationToken);

            comment.Content = request.Content;

            await context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}
