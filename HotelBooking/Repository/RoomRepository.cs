using BookingHotel.Data;
using BookingHotel.Models;
using HotelBooking.Interfaces;

namespace HotelBooking.Repository
{
    public class RoomRepository: Repository<Room>, IRoomRepository
    {
        public RoomRepository(DataContext context) : base(context) { }

    }

}
