using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPostsForUser(int userId) : IQuery<GetPostsForUser.Result>
{
    public record Result(IEnumerable<PostDto> Items);

    public class Handler : IRequestHandler<GetPostsForUser, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetPostsForUser request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .SingleAsync(x => x.Id == request.userId, cancellationToken);

            var posts = await context.Posts.Where(p => p.AuthorId == user.Id).ToListAsync();
            /* TODO sorting */
            return new Result(posts.Select(x => new PostDto(x)));
        }
    }
}
