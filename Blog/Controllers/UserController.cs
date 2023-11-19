using Blog.API.Business.User;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator) => this.mediator = mediator;

    [HttpGet]
    public async Task<GetUsers.Result> GetUsers()
        => await mediator.Send(new GetUsers());

    [HttpGet("{id}")]
    public async Task<UserDto> GetUserById(int id)
        => await mediator.Send(new GetUserById(id));
}
