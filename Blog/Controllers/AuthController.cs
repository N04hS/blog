using Blog.API.Business.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator mediator;

    public AuthController(IMediator mediator) => this.mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUser request)
    {
        var result = await mediator.Send(request);
        return !result.Succeeded ? new BadRequestObjectResult(result) : Ok();
    }

    [HttpPost("login")]
    public async Task<AuthenticateUser.Result> Authenticate([FromBody] AuthenticateUser request)
    {
        var result = await mediator.Send(request);
        if (!result.Successful)
            new UnauthorizedAccessException();  // TODO not same as scriptum
        return result;
    }
}
