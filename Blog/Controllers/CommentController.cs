using Blog.API.Business.Comment;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IMediator mediator;

    public CommentController(IMediator mediator) 
        => this.mediator = mediator;

    [HttpGet]
    public async Task<GetComments.Result> GetComments()
        => await mediator.Send(new GetComments());

    [HttpGet("{id}", Name = "GetCommentById")]
    public async Task<CommentDto> GetCommentById(int id)
        => await mediator.Send(new GetCommentById(id));

    [HttpPost("{postId}")]
    public async Task<ActionResult<CommentDto>> CreateCommentAsync(
        [FromRoute] int postId,
        [FromBody] CommentForCreationDto body)
    {
        var comment = await mediator.Send(new AddComment(postId, body.AuthorName, body.Content));

        return CreatedAtRoute("GetCommentById",
            new
            {
                comment.Id
            }, comment);
    }

    [Authorize]
    public record UpdateCommentContent([MaxLength(256)] string Content);
    [HttpPost("{id}/Update")]
    public Task<Unit> UpdateComment(int id, [FromBody] UpdateCommentContent body)
        => mediator.Send(new UpdateComment(id, body.Content));
}