using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.API.Business.User
{
    public record GetUsers : IQuery<GetUsers.Result>
    {
        public record Result(IEnumerable<UserDto> Items);

        public class Handler : IRequestHandler<GetUsers, Result>
        {
            public Task<Result> Handle(GetUsers request, CancellationToken cancellationToken)
            {
                var users = UserDataStore.Current.Users;

                return Task.FromResult(new Result(users));
            }
        }
    }