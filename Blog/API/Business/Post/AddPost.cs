using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Post;

public record AddPost(int AuthorId, string Title, string Content) : ICommand<PostDto>
{
    public class Handler : IRequestHandler<AddPost, PostDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<PostDto> Handle(AddPost request, CancellationToken cancellationToken)
        {
            // check that user actually exists
            var user = await context.Users.SingleAsync(x => x.Id == request.AuthorId, cancellationToken);

            var post = new Entities.Post(request.Title)
            {
                AuthorId = request.AuthorId,
                Content = request.Content,
                TimeOfCreation = DateTime.Now
            };

            await context.SaveChangesAsync(cancellationToken);
            return new PostDto(post);
        }
    }
}
