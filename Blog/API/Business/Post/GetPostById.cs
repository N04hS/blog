using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record GetPostById(int Id) : IQuery<PostDto>
{
    public class Handler : IRequestHandler<GetPostById, PostDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<PostDto> Handle(GetPostById request, CancellationToken cancellationToken)
            => new PostDto(await context.Posts.SingleAsync(x => x.Id == request.Id, cancellationToken));
    }
}
