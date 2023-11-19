using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.User;

public class GetUsers : IQuery<GetUsers.Result>
{
    public record Result(IEnumerable<UserDto> Items);

    public class Handler : IRequestHandler<GetUsers, Result>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<Result> Handle(GetUsers request, CancellationToken cancellationToken)
            => new Result(
                await context.Users
                .Select(x => new UserDto(x))
                .ToListAsync(cancellationToken));
    }
}
