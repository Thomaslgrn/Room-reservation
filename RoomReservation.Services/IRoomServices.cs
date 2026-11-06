using RoomReservation.Entities;

namespace RoomReservation.Services
{
    public interface IRoomServices
    {
        Task<List<Room>> GetAllRoomsAsync();
        Task<Room?> GetRoomByIdAsync(int id);
        Task<Room> CreateRoomAsync(Room room);
        Task<Room?> UpdateRoomAsync(int id, Room room);
        Task<bool> DeleteRoomAsync(int id);
    }
}