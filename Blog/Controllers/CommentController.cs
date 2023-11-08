using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CommentDto>> GetComments()
    {
        return Ok(CommentDataStore.Current.Comments);
    }

    [HttpGet("id")]
    public ActionResult<IEnumerable<CommentDto>> GetCommentById(int id)
    {
        var result = CommentDataStore.Current.Comments.FirstOrDefault(c => c.Id == id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}