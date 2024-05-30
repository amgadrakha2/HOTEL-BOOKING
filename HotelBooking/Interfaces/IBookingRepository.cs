using BookingHotel.Models;

namespace HotelBooking.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<bool> HasPreviousBookingsAsync(string custNationaId);
        Task<decimal> CountNumberOfNights(DateTime checkIN, DateTime checkOut, int roomId, int numberOfRooms);
    }
}