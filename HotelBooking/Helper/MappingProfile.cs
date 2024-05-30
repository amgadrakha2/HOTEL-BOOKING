using AutoMapper;
using BookingHotel.Models;
using HotelBooking.DTO;

namespace HotelBooking.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<HotelBranch, HotelBranchDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }

    }
}
