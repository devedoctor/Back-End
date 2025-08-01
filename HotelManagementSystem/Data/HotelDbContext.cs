using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelManagementSystem.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        // Database tables
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.RoomId);

            // Seed initial data with static values
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    RoomNumber = "101",
                    RoomType = "Standard",
                    PricePerNight = 100.00m,
                    IsAvailable = true,
                    Description = "Standard room with basic amenities"
                },
                new Room
                {
                    RoomId = 2,
                    RoomNumber = "102",
                    RoomType = "Deluxe",
                    PricePerNight = 150.00m,
                    IsAvailable = true,
                    Description = "Deluxe room with premium amenities"
                },
                new Room
                {
                    RoomId = 3,
                    RoomNumber = "201",
                    RoomType = "Suite",
                    PricePerNight = 250.00m,
                    IsAvailable = true,
                    Description = "Luxury suite with separate living area"
                }
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    StaffId = 1,
                    Name = "John Doe",
                    Position = "Manager",
                    Email = "john@hotel.com",
                    Phone = "1234567890",
                    HireDate = new DateTime(2020, 1, 1), // Static date
                    Salary = 5000.00m
                },
                new Staff
                {
                    StaffId = 2,
                    Name = "Jane Smith",
                    Position = "Receptionist",
                    Email = "jane@hotel.com",
                    Phone = "0987654321",
                    HireDate = new DateTime(2021, 1, 1), // Static date
                    Salary = 3000.00m
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin",
                    Password = "admin123",
                    Role = "Admin"
                },
                new User
                {
                    UserId = 2,
                    Username = "staff",
                    Password = "staff123",
                    Role = "Staff"
                }
            );
        }
    }
}
