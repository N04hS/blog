using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.Comment;

public record AddComment(int PostId, string AuthorName, string Content) : ICommand<CommentDto>
{
    public class Handler : IRequestHandler<AddComment, CommentDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<CommentDto> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var post = await context.Posts
                .SingleAsync(x => x.Id == request.PostId, cancellationToken);

            var comment = new Entities.Comment(request.Content)
            {
                Author = request.AuthorName,
                PostId = post.Id,
                TimeOfCreation = DateTime.Now
            };
            
            post.Comments.Add(comment);
            await context.SaveChangesAsync(cancellationToken);
            return new CommentDto(comment);
        }
    }
}
