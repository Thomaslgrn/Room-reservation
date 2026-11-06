using RoomReservation.DataAccess;
using RoomReservation.DataAccess.Interfaces;
using RoomReservation.Entities;
using Microsoft.EntityFrameworkCore;

namespace RoomReservation.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        
        private readonly AppDbContext _context;
    
        // Task<List<Reservation>> GetAllReservationsAsync();
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        // Task<Reservation> GetReservationByIdAsync(int id);
        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }
        // Task<Reservation> CreateReservationAsync(Reservation reservation);
        public async Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        // Task<bool> DeleteReservationAsync(int id);
        public async Task<bool> DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return false;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}