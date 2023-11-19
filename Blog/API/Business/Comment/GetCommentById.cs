using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record GetCommentById(int CommentId) : IQuery<CommentDto>
{
    public class Handler : IRequestHandler<GetCommentById, CommentDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<CommentDto> Handle(GetCommentById request, CancellationToken cancellationToken)
            => new CommentDto(
                await context.Comments
                .SingleAsync(x => x.Id == request.CommentId, cancellationToken));
    }
}
