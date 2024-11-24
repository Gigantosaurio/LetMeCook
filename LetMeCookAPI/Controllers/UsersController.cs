using Microsoft.AspNetCore.Mvc;
using LetMeCookAPI.Models;
using LetMeCookAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UsersService _service;

    public UsersController(UsersService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetUserById([FromQuery] int id)
    {
        var user = _service.GetUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        var createdUser = _service.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
}
