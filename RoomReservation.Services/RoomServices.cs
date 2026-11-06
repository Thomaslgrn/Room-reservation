using RoomReservation.DataAccess.Interfaces;
using RoomReservation.Entities;

namespace RoomReservation.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRoomRepository _roomRepository;

        public RoomServices(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _roomRepository.GetAllRoomsAsync();
        }

        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            return await _roomRepository.CreateRoomAsync(room);
        }

        public async Task<Room?> UpdateRoomAsync(int id, Room room)
        {
            return await _roomRepository.UpdateRoomAsync(id, room);
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            return await _roomRepository.DeleteRoomAsync(id);
        }
    }
}