namespace HotelBooking.DTO
{
    public class RoomDto
    {
        public int RoomID { get; set; }
        public int BranchID { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string? Status { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
