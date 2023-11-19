using Blog.API.DbContexts;
using Blog.API.Models;
using Fusonic.Extensions.MediatR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Business.User;

public record GetUserById(int Id) : IQuery<UserDto>
{
    public class Handler : IRequestHandler<GetUserById, UserDto>
    {
        private readonly BlogContext context;

        public Handler(BlogContext context) => this.context = context;

        public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
            => new UserDto(
                await context.Users.SingleAsync(x => x.Id == request.Id, cancellationToken));
    }
}
