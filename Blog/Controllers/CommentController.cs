using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IMediator mediator;

    public CommentController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
    {
        var result = await mediator.Send(new GetComments());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetCommentById(int id)
    {
        var result = await mediator.Send(new GetCommentById(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}