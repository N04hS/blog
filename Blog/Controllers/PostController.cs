using Blog.API.Business.Comment;
using Blog.API.Business.Post;
using Blog.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator mediator;

    public PostController(IMediator mediator) 
        => this.mediator = mediator;

    [HttpGet]
    public async Task<GetPosts.Result> GetPosts() 
        => await mediator.Send(new GetPosts());

    [HttpGet("{id}", Name = "GetPostById")]
    public async Task<PostDto> GetPostsById(int id)
        => await mediator.Send(new GetPostById(id));

    [HttpPost("{authorId}")]
    public async Task<ActionResult<PostDto>> CreatePostAsync(
        [FromRoute] int authorId, 
        [FromBody] PostForCreationDto body)
    {
        // TODO change
        var post = await mediator.Send(new AddPost("Noah Siess"/*authorId*/, body.Title, body.Content));

        var route = CreatedAtRoute("GetPostById",
            new
            {
                post.Id
            }, post);

        return route;
    }

    [Authorize]
    public record UpdatePostTitleModel([MaxLength(50)] string Title);
    [HttpPost("{id}/UpdateTitle")]
    public Task<Unit> UpdatePostTitle(int id, [FromBody] UpdatePostTitleModel body)
        => mediator.Send(new UpdatePostTitle(id, body.Title));

    [Authorize]
    public record UpdatePostContentModel([MaxLength(256)] string Content);
    [HttpPost("{id}/UpdateContent")]
    public Task<Unit> UpdatePostContent(int id, [FromBody] UpdatePostContentModel body)
        => mediator.Send(new UpdatePostContent(id, body.Content));

    [Authorize]
    [HttpGet("{id}/Comments")]
    public Task<GetCommentsByPost.Result> GetCommentsByPost(int id)
        => mediator.Send(new GetCommentsByPost(id));

    [HttpGet("{id}/CommentNumber")]
    public Task<int> GetCommentCountByPost(int id)
        => mediator.Send(new GetCommentCountByPost(id));

}
