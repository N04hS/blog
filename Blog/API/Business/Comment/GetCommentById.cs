using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.API.Business.Comment

public record GetCommentById : IQuery<GetCommentById.Result>
{
    public int CommentId { get; }

    public GetCommentById(int commentId)
    {
        CommentId = commentId;
    }

    public record Result(CommentDto Comment);

    public class Handler : IRequestHandler<GetCommentById, Result>
    {
        public Task<Result> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
                
            var comment = CommentDataStore.Current.Comments.FirstOrDefault(c => c.Id == request.CommentId);

            if (comment == null)
            {
                return Task.FromResult(new Result(null));
            }

            return Task.FromResult(new Result(comment));
        }
    }
}
