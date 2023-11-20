using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.API.Business.Comment;
    
public record GetComments : IQuery<GetComments.Result>
{
    public record Result(IEnumerable<CommentDto> Items);

    public class Handler : IRequestHandler<GetComments, Result>
    {
        public Task<Result> Handle(GetComments request, CancellationToken cancellationToken)
        {
            var comments = CommentDataStore.Current.Comments;

            return Task.FromResult(new Result(comments));
        }
    }
}
