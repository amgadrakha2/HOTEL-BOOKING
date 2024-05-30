using BookingHotel.Data;
using BookingHotel.Models;
using HotelBooking.Interfaces;

namespace HotelBooking.Repository
{
    public class HotelBranchRepository : Repository<HotelBranch>, IHotelBranchRepository
    {
        public HotelBranchRepository(DataContext context) : base(context) { }
    }
}
