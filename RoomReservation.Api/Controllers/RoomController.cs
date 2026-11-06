using Microsoft.AspNetCore.Mvc;
using RoomReservation.Dto;
using RoomReservation.Services;
using RoomReservation.Entities;

namespace RoomReservation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomServices _roomService;

    public RoomController(IRoomServices roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRoomsAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetRoomByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] RoomRequestDto roomRequestDto)
    {
        var room = new Room
        {
            Name = roomRequestDto.Name,
            Capacity = roomRequestDto.Capacity
        };

        var createdRoom = await _roomService.CreateRoomAsync(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.Id }, createdRoom);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomRequestDto roomRequestDto)
    {
        var room = new Room
        {
            Name = roomRequestDto.Name,
            Capacity = roomRequestDto.Capacity
        };

        var updatedRoom = await _roomService.UpdateRoomAsync(id, room);
        if (updatedRoom == null)
        {
            return NotFound();
        }
        return Ok(updatedRoom);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var deleted = await _roomService.DeleteRoomAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}