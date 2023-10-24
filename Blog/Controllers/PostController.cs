using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PostDto>> GetPosts(int userId)
    {
        var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound();

        return Ok(user.Posts);
    }

    [HttpGet("{postId}")]
    public ActionResult<IEnumerable<PostDto>> GetPost(int userId, int postId)
    {
        /*
         * would probably make sense to have post ids unique across all users,
         * => then userId is not needed as parameter here
         */

        var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound();

        // find post
        var post = user.Posts.FirstOrDefault(p => p.Id == postId);

        if (post == null)
            return NotFound();

        return Ok(post);
    }
}
