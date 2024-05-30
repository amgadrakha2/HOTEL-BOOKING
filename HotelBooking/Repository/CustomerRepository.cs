using BookingHotel.Data;
using BookingHotel.Models;
using HotelBooking.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }

    }
}
