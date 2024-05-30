namespace HotelBooking.DTO
{
    public class BookingDto
    {
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int BranchID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfRooms { get; set; } = 5;
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalCost { get; set; }
        public RoomDto Room { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
