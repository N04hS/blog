using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.API.Business.User

public record GetUserById : IQuery<GetUserById.Result>
{
    public int UserId { get; }

    public GetUserById(int userId)
    {
        UserId = userId;
    }

    public record Result(UserDto User);

    public class Handler : IRequestHandler<GetUserById, Result>
    {
        public Task<Result> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == request.UserId);

            if (user == null)
            {
                return Task.FromResult(new Result(null));
            }

            return Task.FromResult(new Result(user));
        }
    }
}