using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPosts : IQuery<GetPosts.Result>
{

    public record Result(IEnumerable<PostDto> Items);

    public class Handler : IRequestHandler<GetPosts, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetPosts request, CancellationToken cancellationToken)
            => new Result(await context.Posts.Select(x => new PostDto(x)).ToListAsync(cancellationToken));
    }
}
