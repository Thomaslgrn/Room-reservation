using RoomReservation.Entities;
using Microsoft.EntityFrameworkCore;

namespace RoomReservation.DataAccess;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the relationships and constraints here if needed
        modelBuilder.Entity<User>()
            .HasMany(u => u.Reservations)
            .WithOne()
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Reservations)
            .WithOne()
            .HasForeignKey(res => res.RoomId);
    }
}