using BookingHotel.Data;
using BookingHotel.Models;
using HotelBooking.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository
{
    public class BookingRepository: Repository<Booking>, IBookingRepository
    {
       
        public BookingRepository(DataContext context) : base(context)
        {
           
        }

        public async Task<decimal> CountNumberOfNights(DateTime checkIN, DateTime checkOut, int roomId, int numberOfRooms)
        {
            TimeSpan duration = checkOut - checkIN;
            int numberOfNights = (int)duration.TotalDays;

            var roomPrice = await _context.Rooms
                                              .Where(b => b.RoomID == roomId)
                                              .Select(b => b.PricePerNight)
                                              .FirstOrDefaultAsync();

            decimal totalAmount =numberOfNights * numberOfRooms * roomPrice.Value;
            decimal discountFactor = (100 - 5) / 100;
            decimal discountedTotalAmount = totalAmount * discountFactor;

            return totalAmount;
        }

        public async Task<bool> HasPreviousBookingsAsync(string custNationalId)
        {   
            return await _context.Bookings
                .Include(b => b.Customers)
                .AnyAsync(b => b.Customers.NationalID == custNationalId);
            
        }
        
    }
}
