using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<PostDto>> GetPosts()
    {
        var allPosts = PostDataStore.Current.Posts;
        
        return Ok(allPosts);
    }

    [HttpGet("{userId}", Name = "GetPosts")]
    public ActionResult<IEnumerable<PostDto>> GetPosts(int userId)
    {
        /* get all posts from store */
        var allPosts = PostDataStore.Current.Posts;

        /* check if user actually exists */
        var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound();

        /* filter posts for user */
        var posts = allPosts.Where(p => p.AuthorId == user.Id);

        return Ok(posts);
    }

    [HttpGet("{userId}/{postId}")]
    public ActionResult<IEnumerable<PostDto>> GetPost(int userId, int postId)
    {
        /*
         * TODO: is there a way to specify which part of query was not found?
         */

        /* get all posts from store */
        var allPosts = PostDataStore.Current.Posts;

        /* check if user actually exists */
        var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
            return NotFound();

        /* filter posts for user */
        var posts = allPosts.Where(p => p.AuthorId == user.Id);

        /* filter posts for specific post */
        var post = posts.FirstOrDefault(p => p.Id == postId);

        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpPost]
    public ActionResult<PostDto> CreatePost(int authorId, PostForCreationDto post)
    {
        var author = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == authorId);

        if (author == null)
            return NotFound();

        var maxPostId = PostDataStore.Current.Posts.Count();

        var finalPost = new PostDto()
        {
            Id = ++maxPostId,
            AuthorId = authorId,
            Title = post.Title,
            Content = post.Content
        };

        PostDataStore.Current.Posts.Add(finalPost);

        return CreatedAtRoute("GetPosts",
            new
            {
                userId = authorId
            },
            finalPost);
    }

    [HttpPut("{postId}")]
    public ActionResult UpdatePost(int postId, PostForUpdateDto updatedPost)
    {
        var postFromStore = PostDataStore.Current.Posts.FirstOrDefault(p => p.Id == postId);

        if (postFromStore == null)
            return NotFound();

        postFromStore.Title = updatedPost.Title;
        postFromStore.Content = updatedPost.Content;

        return NoContent();
    }
}
