using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingHotel.Models
{
    public class Room
    {
        public int RoomID { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public string  RoomType { get; set; }

        public decimal? PricePerNight { get; set; }

        [Required]
        public string? Status { get; set; }

        public int BranchID { get; set; }

        public HotelBranch Branche { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
