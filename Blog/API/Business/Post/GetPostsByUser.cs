using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPostsByUser(int UserId) : IQuery<GetPostsByUser.Result>
{
    public record Result(IEnumerable<PostDto> Items);

    public class Handler : IRequestHandler<GetPostsByUser, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetPostsByUser request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .SingleAsync(x => x.Id == request.UserId, cancellationToken);

            var posts = await context.Posts
                .Where(p => p.AuthorId == user.Id)
                .ToListAsync(cancellationToken);

            /* TODO sorting */
            return new Result(posts.Select(x => new PostDto(x)));
        }
    }
}
