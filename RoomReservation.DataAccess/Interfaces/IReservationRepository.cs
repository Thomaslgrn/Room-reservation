using RoomReservation.Entities;

namespace RoomReservation.DataAccess.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(int id);
    }
}