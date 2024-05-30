namespace HotelBooking.DTO
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public decimal Cost { get; set; }
        public DateTime PaymentDate { get; set; }
        public BookingDto Booking { get; set; }
    }
}
