using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;

namespace Blog.API.Business.Post;

public record AddPost(string AuthorName, string Title, string Content) : ICommand<PostDto>
{
    public class Handler : IRequestHandler<AddPost, PostDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<PostDto> Handle(AddPost request, CancellationToken cancellationToken)
        {
            var post = new Entities.Post(request.Title)
            {
                Author = request.AuthorName,
                Content = request.Content,
                TimeOfCreation = DateTime.Now
            };

            context.Add(post);
            await context.SaveChangesAsync(cancellationToken);
            return new PostDto(post);
        }
    }
}
