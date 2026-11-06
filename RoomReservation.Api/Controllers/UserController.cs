using Microsoft.AspNetCore.Mvc;
using RoomReservation.Dto;
using RoomReservation.Entities;
using RoomReservation.Services;

namespace RoomReservation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userService;

    public UserController(IUserServices userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }


    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserRequestDto userRequestDto)
    {
        var user = new User
        {
            FirstName = userRequestDto.FirstName,
            LastName = userRequestDto.LastName,
            Email = userRequestDto.Email,
        };

        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequestDto userRequestDto)
    {
        var user = new User
        {
            FirstName = userRequestDto.FirstName,
            LastName = userRequestDto.LastName,
            Email = userRequestDto.Email,
        };

        var updatedUser = await _userService.UpdateUserAsync(id, user);
        if (updatedUser == null)
        {
            return NotFound();
        }
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}