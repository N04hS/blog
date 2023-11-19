using Blog.API.Business.Post;
using Blog.API.Models;
using MediatR;
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

    /* TODO does work but throws swagger error */
    [HttpGet]
    public async Task<GetPosts.Result> GetPosts() 
        => await mediator.Send(new GetPosts());

    [HttpGet("{id}")]
    public async Task<PostDto> GetPostsById(int id)
        => await mediator.Send(new GetPostById(id));

    /* TODO move into user controller */
    [HttpGet("{userId}/posts")]
    public async Task<GetPostsForUser.Result> GetPostsForUser(int userId)
        => await mediator.Send(new GetPostsForUser(userId));

    [HttpPost("{authorId}")]
    public async Task<ActionResult<PostDto>> CreatePostAsync(
        [FromRoute] int authorId, 
        [FromBody] PostForCreationDto body)
    {
        var post = await mediator.Send(new AddPost(authorId, body.Title, body.Content));

        return Ok(post);

        /* TODO fix CreatedAtRoute */

        var route = CreatedAtRoute("GetPostsById",
            new
            {
                post.Id
            }, post);

        return route;
    }

    public record UpdatePostTitleModel([MaxLength(50)] string Title);
    [HttpPost("{postId}/UpdateTitle")]
    public Task<Unit> UpdatePostTitle(int postId, [FromBody] UpdatePostTitleModel body)
        => mediator.Send(new UpdatePostTitle(postId, body.Title));

    public record UpdatePostContentModel([MaxLength(256)] string Content);
    [HttpPost("{postId}/UpdateContent")]
    public Task<Unit> UpdatePostContent(int postId, [FromBody] UpdatePostContentModel body)
        => mediator.Send(new UpdatePostContent(postId, body.Content));
}
