
using RoomReservation.DataAccess.Interfaces;
using RoomReservation.Entities;

namespace RoomReservation.Services
{

    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        // Task<User?> GetUserByIdAsync(int id);
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }
        //Task<User> CreateUserAsync(User user);
        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
        //Task<User?> UpdateUserAsync(int id, User user);
        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            return await _userRepository.UpdateUserAsync(id, user);
        }
        //Task<bool> DeleteUserAsync(int id);
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
    // Task<List<User>> GetAllUsersAsync();
   
}