using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record GetPostsForUser(int userId) : IQuery<GetPostsForUser.Result>
{
    public record Result(IEnumerable<PostDto> Items);

    public class Handler : IRequestHandler<GetPostsForUser, Result>
    { 
        public Task<Result> Handle(GetPostsForUser request, CancellationToken cancellationToken)
        {
            var user = UserDataStore.Current.Users
                .Single(u => u.Id == request.userId);

            /* TODO sorting */

            var posts = PostDataStore.Current.Posts.Where(p => p.AuthorId == user.Id);
            return Task.FromResult(new Result(posts));
        }
    }
}
