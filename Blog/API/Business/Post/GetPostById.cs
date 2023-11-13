using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record GetPostById(int Id) : IQuery<PostDto>
{
    public class Handler : IRequestHandler<GetPostById, PostDto>
    {
        public Task<PostDto> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            return Task.FromResult(PostDataStore.Current.Posts.Single(p => p.Id == request.Id));
        }
    }
}
