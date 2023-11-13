using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
        return Ok(UserDataStore.Current.Users);
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<UserDto>> GetUserById(int id)
    {
        var result =
            UserDataStore.Current.Users.FirstOrDefault(x => x.Id == id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
