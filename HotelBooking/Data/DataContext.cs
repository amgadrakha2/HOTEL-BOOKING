using BookingHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotel.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelBranch> Branches { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }


    }
}
