using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record GetComments : IQuery<GetComments.Result>
{
    public record Result(IEnumerable<CommentDto> Items);

    public class Handler : IRequestHandler<GetComments, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetComments request, CancellationToken cancellationToken)
            => new Result(
                await context.Comments
                .Select(x => new CommentDto(x))
                .ToListAsync(cancellationToken));
    }
}
