namespace RoomReservation.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}