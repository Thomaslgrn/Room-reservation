namespace RoomReservation.Dto
{
    public record RoomRequestDto
    {
        public required string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }

    public record RoomResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Capacity { get; set; }
    }
}