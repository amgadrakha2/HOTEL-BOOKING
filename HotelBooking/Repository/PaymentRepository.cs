using BookingHotel.Data;
using BookingHotel.Models;
using HotelBooking.Interfaces;

namespace HotelBooking.Repository
{
    public class PaymentRepository: Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext context) : base(context) { }

    }
}
