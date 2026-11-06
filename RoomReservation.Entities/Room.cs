namespace RoomReservation.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
        //les rooms doivent etre accessible par horaires, donc on a besoin d'un lien avec les reservations
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}